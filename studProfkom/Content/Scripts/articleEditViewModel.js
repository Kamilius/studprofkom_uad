$(function () {
    tinymce.init({
    	selector: "textarea.article-text",
    	plugins: [
        "advlist autolink lists link image charmap preview anchor",
        "searchreplace visualblocks code fullscreen",
        "insertdatetime media table contextmenu paste"
    	]
    });

    //$('#EventStartDate').datetimepicker({
    //	language: 'ua',
    //	initialDate: initialDate
    //});
});