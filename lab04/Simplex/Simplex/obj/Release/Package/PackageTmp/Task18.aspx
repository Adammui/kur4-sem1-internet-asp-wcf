<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task18.aspx.cs" Inherits="Simplex.Task18" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ajax</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="Scripts\jquery-3.6.1.min.js"></script>
    <script>
        function Sum() {
            const data = {
                x: parseInt($("#x").val()),
                y: parseInt($("#y").val())
                //x: parseInt(document.getElementById("x").value),
               // y: parseInt(document.getElementById("y").value)
            };
            $.ajax({
                url: "Simplex.asmx/Adds",
                type: "GET",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: data,
                success: result => {
                    $("#result").val(result.d);
                },
                error: error => {
                    console.log(error);
                }
            })
        }
    </script>
</head>
<body>
    <form id="sumform" runat="server">
        <div>
            <div>
                <input type="text" id="x"/>
                <input type="text" id="y"/>
                <input type="button" onclick="Sum()" value="Calculate" />
            </div>
            <div>
                <input type="text" id="result"/>
            </div>
        </div>
    </form>
</body>
</html>
