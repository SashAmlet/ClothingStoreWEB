function drawChart() {
    $.get('/api/Chart/GetItemsByCategories', function (GetGrades) {
        data = google.visualization.arrayToDataTable(GetGrades, false);
        var option = {
            title: "Number of items in the corresponding category",
            width: 500,
            height: 500
        };
        chart = new google.visualization.PieChart(document.getElementById('chart1'));
        chart.draw(data, option);
        
    }).fail(function (jqXHR, textStatus, errorThrown) {
        // Код обработки ошибки
        console.log("ERROR: " + textStatus, errorThrown);
    });
}