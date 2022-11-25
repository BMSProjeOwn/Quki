
for (var a = 0; a < document.getElementById("custom-tabs-one-messages").innerHTML.split('_____').length; a++) {

    var name = document.getElementById("custom-tabs-one-messages").innerHTML.split('_____')[a].substring(0, 6).replace('p', '').replace('l', '').replace('a', '').replace('\"', '').replace('n', '').trim()
    try {
            var b = parseInt(name);
            if (b >= 0) {
                name = '_____' + name;
                const editor = document.getElementById(name);
                CKEDITOR.replace(editor, config);
                
            }
        } catch (err) {
        }

    }