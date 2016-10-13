//Global vars

var HRexpert =
{
    Dialogs: {},
    ConfigureHiddenDiv: function()
    {
        HRexpert.HiddenDiv = $('<div/>').attr({ class: "hiddenDiv" });
        $(document.body).append(HRexpert.HiddenDiv);
    },
    ConfigurePanels : function ()
    {
        var panelHeaders = $('.panel-heading');
        var collapsButton = $('<input/>').attr({ type: 'button', value: '+', class: "btn btn-link" });
        collapsButton.click(function () {
            var _this = $(this);
            var parent = _this.parent();
            parent.next().toggleClass("collapsed-body");
            if (_this.val() === "+") _this.val("-");
            else _this.val("+");
        });
        panelHeaders.prepend(collapsButton);
    },    
    ConfigureDatePickers: function ()
    {
        $('.NeedDatePicker').datepicker({ dateFormat: 'dd.mm.yy' });
    },
    ConfigureDepartmentTree: function()
    {
        return $.get("/ru/Department/GetTree", {})
            .done(function (data) { HRexpert.DepartmentTreeData = data });
        
    },
    Factory: {
        CreateDepartmentSelectDialog: function (id, name, onFinish) {
            createDialog = function()
            {
                var dialogId = id + '_SelectDialog';
                if (!HRexpert.Dialogs[dialogId]) {
                    var dialog = $('<div/>').attr({ id: dialogId, title: 'Выбор подразделения' });
                    var searchinput = $('<input/>').attr({ type: 'text' });
                    var searchButton = $('<input/>').attr({ type: 'button', value: 'Искать' });
                    
                    HRexpert.Dialogs[dialogId] = dialog
                    var tree = $('<div/>').attr({ id: id + '_DepartmentTree' });
                    tree.jstree({
                        "core": {
                            "animation": 0,
                            "check_callback": true,
                            "themes": { "stripes": true },
                            'data': HRexpert.DepartmentTreeData
                        },
                        "search": {
                            "show_only_matches": true
                        },
                        "plugins": ["search"]
                    });
                    searchButton.click(function () { tree.jstree(true).search(searchinput.val()); });
                    dialog.append(searchinput);
                    dialog.append(searchButton);
                    dialog.append(tree);
                    HRexpert.HiddenDiv.append(dialog);
                    dialog.dialog({
                        autoOpen: false,
                        width: 400,
                        height: 400,
                        buttons: {
                            "Выбрать": function () {
                                var selected = tree.jstree(true).get_selected(true);
                                if (selected[0]) {                                
                                    $('#' + id).val(selected[0].id);
                                    $('#' + name).val(selected[0].text);
                                }
                                $(this).dialog("close");
                            },
                            "Отмена": function () {
                                $(this).dialog("close");
                            }
                        }
                    });
                    return dialog;
                }
                else return HRexpert.Dialogs[dialogId];
            }
            if (!HRexpert.DepartmentTreeData) {
                HRexpert.ConfigureDepartmentTree().always(function () { onFinish(createDialog()); });
            }
            else onFinish(createDialog());
        }
    }
    ,
    TypicalInit : function()
    {
        this.ConfigureHiddenDiv();
        this.ConfigurePanels();
        this.ConfigureDatePickers();
    }
}
    
