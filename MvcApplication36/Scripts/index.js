$(function() {
    $("#doIt").on('click', function() {
        var id = $("#personId").val();
        $.post('/home/getperson', { id: id }, function(person) {
            console.log(person);
        });
    });
});