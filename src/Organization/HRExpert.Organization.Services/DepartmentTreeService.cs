using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using HRExpert.Organization.DTO;
using HRExpert.Organization.Data.Models;
using HRExpert.Organization.Data.Abstractions;
using ExtCore.Data.Abstractions;
namespace HRExpert.Organization.Services
{
    public class DepartmentTreeService: Abstraction.IDepartmentTreeService
    {
        private IHttpContextAccessor contextaccessor;
        public DepartmentTreeService(IHttpContextAccessor contextaccessor)
        {
            this.contextaccessor = contextaccessor;            
            Initialize();
        }
        private List<DepartmentDto> tree;        
        private List<DepartmentLink> Links { get; set; }
        private List<DepartmentDto> AllDepartments { get; set; }
        private DateTime LastCache;
        private int[][] accessiblenessMatrix;
        private long? accessiblenessMatrixSize;
        #region Private
        
        private void CreateTree()
        {
            foreach(var el in AllDepartments)
            {
                el.Childs = new List<DepartmentDto>();
                el.Childs.AddRange(AllDepartments.Where(x => Links.Any(y => y.LeftId==el.Id && y.RightId == x.Id)));
            }
            DepartmentTree = AllDepartments.Where(x => !Links.Any(y => x.Id == y.RightId)).ToList();
        }

        private void CreateAccessiblenessMatrix()
        {            
            //Вычисляем размер матрицы
            long max = AllDepartments.Max(x => x.Id);
            this.accessiblenessMatrixSize = max;
            //Создаём матрицу смежности
            int[][] E = new int[max][];
            for (int i = 0; i < max; i++)
                E[i] = new int[max];
            foreach (var el in Links)
            {
                E[el.LeftId - 1][el.RightId - 1]++;
            }
            //Вычисляем матрицу достижимости
            this.accessiblenessMatrix = FloydWarshall(E, max);
        }
        /// <summary>
        /// Строит матрицу достижимости по матрице смежности
        /// </summary>
        /// <param name="E"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int[][] FloydWarshall(int[][] E, long n)
        {
            int[][] W = E;

            for (long k = 0; k < n; k++)
                for (long i = 0; i < n; i++)
                    for (long j = 0; j < n; j++)
                        W[i][j] = (W[i][j] + (W[i][k] * W[k][j]));
            return W;
        }
        #endregion
        #region Public
        public List<DepartmentDto> DepartmentTree { get { Console.WriteLine("Последнее обновление: " + LastCache); return tree; } private set { this.tree = value; } }
        /// <summary>
        /// Проверка достижимости
        /// </summary>
        /// <param name="ParentId"></param>
        /// <param name="ChildId"></param>
        /// <returns></returns>
        public bool IsChildDepartment(long ParentId, long ChildId)
        {            
            if (ParentId > accessiblenessMatrixSize || ChildId > accessiblenessMatrixSize) return false;
            return accessiblenessMatrix[ParentId - 1][ChildId - 1] > 0;

        }        
        public void Initialize()
        {
            var storage = contextaccessor.HttpContext.ApplicationServices.GetService<IStorage>();
            
            IDepartmentLinksRepository departmentLinksRepository = storage.GetRepository<IDepartmentLinksRepository>();
            IDepartmentRepository departmentRepository = storage.GetRepository<IDepartmentRepository>();
            var allDepartments = departmentRepository.All().Select(x => new DepartmentDto { Id = x.Id, Name = x.Name, Organization = new OrganizationDto { Id = x.OrganizationId } }).ToList();
            var links = departmentLinksRepository.All();
            this.AllDepartments = allDepartments;
            this.Links = links;
            LastCache = DateTime.Now;
            CreateTree();
            CreateAccessiblenessMatrix();
          
        }
        #endregion
    }
}
