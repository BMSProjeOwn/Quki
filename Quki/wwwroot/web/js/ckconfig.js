const config = {
    filebrowserImageBrowseUrl: "/imagebrowser",
    filebrowserImageWindowWidth: 750,
    filebrowserImageWindowHeight: 606,
    filebrowserBrowseUrl: "/linkbrowser",
    filebrowserWindowWidth: 350,
    filebrowserWindowHeight: 500
};
const editor = document.getElementById("editor");
CKEDITOR.replace(editor, config);