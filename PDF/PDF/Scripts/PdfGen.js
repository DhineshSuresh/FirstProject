
function fngeneratePdf()
{
    $.ajax({
        url: "/Home/ItextSharpPdfGen/",
        success: function (result) {


           
        }
    });
}

//function fngeneratePdf() {
//    $.ajax({
//        url: "/Home/ItextSharpPdfMulti/",
//        success: function (result) {



//        }
//    });
//}

function fngenerateItext7()
{
    $.ajax({
        url: "/PdfIText7/multilayoutpdf/",
        success: function (result) {

        }
    });
}

function fngeneratePdfitext()
{
    $.ajax({
        url: "/Home/ItextPdfGen/",
        success: function (result) {

        }
    });
}

function fnspirePdf()
{
    $.ajax({
        url: "/SpirePdf/PdfGenerationSpire/",
        success: function (result) {



        }
    });
}

function fnclicklinkedln()
{
    //$.ajax({
    //    url: "/Home/Authorize/",
    //    success: function (result) {



    //    }
    //});
    window.location.href = "/Home/Authorize/";
}

function fnclicksignout()
{
    window.location.href = "/Home/PdfGeneration/";
}

function fnGenerateXml() {
    $.ajax({
        url: "/Xml/GenerateXmlFile/",
        success: function (result) {



        }
    });
}