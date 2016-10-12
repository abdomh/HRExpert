function ConfigurePanels()
{
    var panelHeaders = $('.panel-heading');
    var collapsButton = $('<input/>').attr({ type: 'button', value: '+', class: "btn btn-link" });
    collapsButton.click(function () {
        var _this = $(this);
        var parent = _this.parent();
        parent.next().toggleClass("collapsed-body");
        if (_this.val() == "+") _this.val("-");
        else _this.val("+");
    }
    );
    panelHeaders.prepend(collapsButton);
}
function ConfigureDatePickers()
{
    $('.NeedDatePicker').datepicker({ dateFormat: 'dd.mm.yy' });
}
$(document).ready(function () {    
    ConfigurePanels();
    ConfigureDatePickers();
});