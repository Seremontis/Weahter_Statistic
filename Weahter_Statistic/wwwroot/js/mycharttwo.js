var arrayRiseSet1, arrayRiseSet2;

DeclareArray();
FillArray();


function DeclareArray() {
    arrayRiseSet1 = new Array(arrayInfo1.length);
    arrayRiseSet2 = new Array(arrayInfo1.length);
}


function FillArray() {
    for (var i = 0; i < arrayInfo1.length; i++) {
        arrayRiseSet1[i] = new Array(2);
        arrayRiseSet1[i][0] = SetTime(arrayInfo1[i].sunriseTime);
        arrayRiseSet1[i][1] = SetTime(arrayInfo1[i].sunsetTime);

        arrayRiseSet2[i] = new Array(2);
        arrayRiseSet2[i][0] = SetTime(arrayInfo2[i].sunriseTime);
        arrayRiseSet2[i][1] = SetTime(arrayInfo2[i].sunsetTime);
    }
}

function SetTime(array) {
    var date = Date.UTC(2019, 0, 1, array[0], array[1], array[2])
    return date;
}
var subtitleTxt = 'Dane od ' + arrayDate[0] + ' do ' + arrayDate[arrayDate.length - 1];
var city1 = arrayInfo1[0].place;
var city2 = arrayInfo2[0].place;

$(document).ready(function () {
    Highcharts.chart('sunriset', {

        chart: {
            type: 'columnrange',
            inverted: true
        },

        title: {
            text: 'Zestawienie czasu słońca na niebie'
        },

        subtitle: {
            text: subtitleTxt
        },

        xAxis: {
            type: 'datetime',
            categories: arrayDate
        },

        yAxis: {
            type: 'datetime',
            tickInterval: 3600,
            min: Date.UTC(2019, 0, 1, 0, 0, 0),
            max: Date.UTC(2019, 0, 2, 0, 0, 0),
            dateTimeLabelFormats: {
                day: '%H:%M'
            },
        },

        tooltip: {
            enabled: false
        },

        plotOptions: {
            columnrange: {
                dataLabels: {
                    enabled: true,
                    formatter: function () {
                        return Highcharts.dateFormat('%H:%M', this.y)
                    },
                    x: 24
                }
            }
        },

        legend: {
            enabled: true
        },

        series: [{
            name: city1,
            data: arrayRiseSet1,
            color: '#D25252'
        },
        {
            name: city2,
            data: arrayRiseSet2,
            color:'#ce5c00'
        }]

    });

});