
$(document).ready(function () {
    Highcharts.chart('sunriset', {

        chart: {
            type: 'columnrange',
            inverted: true
        },

        title: {
            text: 'Temperature variation by month'
        },

        subtitle: {
            text: 'Zestawienie czasu słońca na niebie'
        },

        xAxis: {
            categories: ['1', '2', '3', '4', '5', '6',
                '7', '8', '9', '10', '11', '12']
        },

        yAxis: {
            title: {
                text: 'Godzina'
            },
            min:0,
            max:24
        },

        tooltip: {
            valueSuffix: '°C'
        },

        plotOptions: {
            columnrange: {
                dataLabels: {
                    enabled: true,
                    format: '{y}°C',
                    x: 24
                    
                }
            }
        },

        legend: {
            enabled: false
        },

        series: [{
            name: 'Temperatures',
            data: [
                [9.9, 10.3],
                [8.6, 8.5],
                [10.2, 11.8],
                [1.7, 12.2],
                [0.6, 23.1],
                [3.7, 25.4],
                [6.0, 26.2],
                [6.7, 21.4],
                [3.5, 19.5],
                [1.3, 16.0],
                [8.7, 9.4],
                [9.0, 8.6]
            ]
        }]

    });
})