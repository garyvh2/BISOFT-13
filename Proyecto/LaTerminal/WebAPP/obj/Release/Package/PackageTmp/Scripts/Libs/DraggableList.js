// LIB CODE
window.DraggableList = function (id) {
    var _this = this;
    _this.id = id;
    // Container
    _this.el = $(document.createElement('div'));
    // List
    _this.list = $(document.createElement('ul')).attr({
        id: id,
        class: 'DraggableList'
    }).css ({
        padding: 0
    });
    _this.list.sortable();
    // Add Button
    _this.add = $(document.createElement('button')).attr({
        id: 'add-' + id,
        class: 'btn DraggableListAdd'
    }).html('<i class="fas fa-plus"></i>');
    _this.add.click(function (ev){
        _this.addInput();
    });
    // Add Elements into container
    this.el.append([this.list, this.add]);
} 
DraggableList.prototype.get = function () {
    return this.el;
}
DraggableList.prototype.addInput = function () {
    var _this = this;
    var length = $('#' + _this.id + ' *').filter(':input').length;
    _this.list.append(_this.createInput(_this.id + "-" + length + 1))
}
DraggableList.prototype.createInput = function (id) {
    // Input Group
    var input_group =  $(document.createElement('li')).attr({
        id: 'group-' + id,
        class: 'draggable-list-item input-group ui-state-default'
    }).css({
        margin: "5px 0"
    })
    // >> Input
    var input = $(document.createElement('input')).attr({
        id: 'input-' + id,
        class: 'form-control'
    });

    // Preppend (Draggable Button)
    var pre_append_span     = $(document.createElement('span')).addClass('input-group-text').css({
        cursor: "pointer"
    }).html('<i class="fas fa-bars"></i>')
    var pre_append          = $(document.createElement('div')).addClass('input-group-prepend').append(pre_append_span);
    // Post Append (Delete Button)
    var post_append_span    = $(document.createElement('span')).addClass('input-group-text').css({
        cursor: "pointer"
    }).html('<i class="fas fa-times"></i>')
    var post_append         = $(document.createElement('div')).addClass('input-group-append').append(post_append_span);
    post_append.click(function (ev) {
        $('#' + 'group-' + id).remove();
    })
    // Append into parent
    input_group.append([pre_append,input,post_append]);
    return input_group;
}
var getValues = function () {
    var _this = $(this);
    var values = [];
    
    $('#' + _this.attr('id') + ' *').filter(':input').each(function (input) {
        values.push(this.value);
    });
    return _.compact(values);
}
$.fn.getData = getValues;
DraggableList.prototype.getValues = getValues