var arrayRiseSet;
if (arrayInfo != null) {
    arrayRiseSet = new Array(arrayInfo.length);
    for (let i = 0; i < arrayInfo.length; i++) {
        arrayRiseSet[i] = new Array(2);
        arrayRiseSet[i][0] = arrayInfo[i].sunriseStamp;
        arrayRiseSet[i][1] = arrayInfo[i].sunsetStamp;
    }
}

var ppp = [[2.1, 2.3],[5.8, 9.9]];

$(document).ready(function () {

    // ManyDaysCity sun
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
            type: 'datetime',
            categories: arrayDate
        },

        yAxis: {
            labels: {
                formatter: function () {
                    return Highcharts.dateFormat('%H:%M', this.value)
                }
            },
            min: 0,
            max: 864000000000,
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
            enabled: false
        },

        series: [{
            name: 'Godzina',
            data: arrayRiseSet,
        }]

    });

    // ManyDaysCity pressure
    Highcharts.chart('pressure', {
        chart: {
            zoomType: 'x'
        },
        title: {
            text: 'Ciśnienie w danym okresie'
        },
        subtitle: {
            text: document.ontouchstart === undefined ?
                ' ' : ' '
        },
        xAxis: {
            type: 'datetime',
            labels: {
                formatter: function () {
                    return Highcharts.dateFormat("%b %e", this.value)
                }
            }
        },
        yAxis: {
            title: {
                text: 'Ciśnienie'
            },
        },
        legend: {
            enabled: false
        },
        plotOptions: {
            area: {
                fillColor: {
                    linearGradient: {
                        x1: 0,
                        y1: 0,
                        x2: 0,
                        y2: 1
                    },
                    stops: [
                        [0, Highcharts.getOptions().colors[0]],
                        [1, Highcharts.Color(Highcharts.getOptions().colors[0]).setOpacity(0).get('rgba')]
                    ]
                },
                marker: {
                    radius: 2
                },
                lineWidth: 1,
                states: {
                    hover: {
                        lineWidth: 1
                    }
                },
                threshold: null
            }
        },

        series: [{
            labels: {
                formatter: function () {
                    return Highcharts.dateFormat("%b %e", this.value)
                }
            },
            type: 'area',
            name: 'hPa',
            data: [[1519862400000, 1024], [1519948800000, 1014], [1520035200000, 1000], [1520121600000, 1040]],         
        }]
    });

    // ManyDaysCity humidity
    Highcharts.chart('humidity', {
        chart: {
            type: 'bar'
        },
        title: {
            text: 'Historic World Population by Region'
        },
        subtitle: {
            text: 'Source: <a href="https://en.wikipedia.org/wiki/World_population">Wikipedia.org</a>'
        },
        xAxis: {
            type:'datetime',
            categories: [1519862400000,1519948800000,1520035200000, 1520121600000],
            title: {
                text: null
            },
            labels: {
                formatter: function () {
                    return Highcharts.dateFormat("%b %e", this.value)
                }
            }
        },
        yAxis: {
            min: 0,
            max:100,
            title: {
                text: 'Procent wilgotności',
                align: 'high'
            },
            labels: {
                overflow: 'justify'
            }
        },
        tooltip: {
            valueSuffix: ' %'
        },
        plotOptions: {
            bar: {
                dataLabels: {
                    enabled: true
                }
            }
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'top',
            x: -40,
            y: 80,
            floating: true,
            borderWidth: 1,
            backgroundColor: ((Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'),
            shadow: true
        },
        credits: {
            enabled: false
        },
        series: [{
            name: 'City',
            data: [60, 31, 35, 20, 100]
        }]
    });

    // ManyDaysCity cloudy
    Highcharts.chart('cloudy', {
        chart: {
            type: 'bar'
        },
        title: {
            text: 'Historic World Population by Region'
        },
        subtitle: {
            text: 'Source: <a href="https://en.wikipedia.org/wiki/World_population">Wikipedia.org</a>'
        },
        xAxis: {
            type: 'datetime',
            categories: [1519862400000, 1519948800000, 1520035200000, 1520121600000],
            title: {
                text: null
            },
            labels: {
                formatter: function () {
                    return Highcharts.dateFormat("%b %e", this.value)
                }
            }
        },
        yAxis: {
            min: 0,
            max: 100,
            title: {
                text: 'Procent wilgotności',
                align: 'high'
            },
            labels: {
                overflow: 'justify'
            }
        },
        tooltip: {
            valueSuffix: ' %'
        },
        plotOptions: {
            bar: {
                dataLabels: {
                    enabled: true
                }
            }
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'top',
            x: -40,
            y: 80,
            floating: true,
            borderWidth: 1,
            backgroundColor: ((Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'),
            shadow: true
        },
        credits: {
            enabled: false
        },
        series: [{
            name: 'City',
            data: [60, 31, 35, 20, 100]
        }]
    });


    //ManyDaysCity temperatures
    var ranges = [
        [1246406400000, 14.3, 27.7],
        [1246492800000, 14.5, 27.8],
        [1246579200000, 15.5, 29.6],
        [1246665600000, 16.7, 30.7],
        [1246752000000, 16.5, 25.0],
        [1246838400000, 17.8, 25.7],
        [1246924800000, 13.5, 24.8],
        [1247011200000, 10.5, 21.4],
        [1247097600000, 9.2, 23.8],
        [1247184000000, 11.6, 21.8],
        [1247270400000, 10.7, 23.7],
        [1247356800000, 11.0, 23.3],
        [1247443200000, 11.6, 23.7],
        [1247529600000, 11.8, 20.7],
        [1247616000000, 12.6, 22.4],
        [1247702400000, 13.6, 19.6],
        [1247788800000, 11.4, 22.6],
        [1247875200000, 13.2, 25.0],
        [1247961600000, 14.2, 21.6],
        [1248048000000, 13.1, 17.1],
        [1248134400000, 12.2, 15.5],
        [1248220800000, 12.0, 20.8],
        [1248307200000, 12.0, 17.1],
        [1248393600000, 12.7, 18.3],
        [1248480000000, 12.4, 19.4],
        [1248566400000, 12.6, 19.9],
        [1248652800000, 11.9, 20.2],
        [1248739200000, 11.0, 19.3],
        [1248825600000, 10.8, 17.8],
        [1248912000000, 11.8, 18.5],
        [1248998400000, 10.8, 16.1]
    ],
        averages = [
            [1246406400000, 21.5],
            [1246492800000, 22.1],
            [1246579200000, 23],
            [1246665600000, 23.8],
            [1246752000000, 21.4],
            [1246838400000, 21.3],
            [1246924800000, 18.3],
            [1247011200000, 15.4],
            [1247097600000, 16.4],
            [1247184000000, 17.7],
            [1247270400000, 17.5],
            [1247356800000, 17.6],
            [1247443200000, 17.7],
            [1247529600000, 16.8],
            [1247616000000, 17.7],
            [1247702400000, 16.3],
            [1247788800000, 17.8],
            [1247875200000, 18.1],
            [1247961600000, 17.2],
            [1248048000000, 14.4],
            [1248134400000, 13.7],
            [1248220800000, 15.7],
            [1248307200000, 14.6],
            [1248393600000, 15.3],
            [1248480000000, 15.3],
            [1248566400000, 15.8],
            [1248652800000, 15.2],
            [1248739200000, 14.8],
            [1248825600000, 14.4],
            [1248912000000, 15],
            [1248998400000, 13.6]
        ];
    Highcharts.chart('temperatures', {

        title: {
            text: 'July temperatures'
        },

        xAxis: {
            type: 'datetime'
        },

        yAxis: {
            title: {
                text: null
            }
        },

        tooltip: {
            crosshairs: true,
            shared: true,
            valueSuffix: '°C'
        },

        legend: {
        },

        series: [{
            name: 'Temperature',
            data: averages,
            zIndex: 1,
            marker: {
                fillColor: 'white',
                lineWidth: 2,
                lineColor: Highcharts.getOptions().colors[0]
            }
        }, {
            name: 'Range',
            data: ranges,
            type: 'arearange',
            lineWidth: 0,
            linkedTo: ':previous',
            color: Highcharts.getOptions().colors[0],
            fillOpacity: 0.3,
            zIndex: 0,
            marker: {
                enabled: false
            }
        }]
    });


    //ManyDaysCity rainy
    Highcharts.chart('rainy', {
        chart: {
            type: 'spline'
        },
        title: {
            text: 'Ilość opadów'
        },
        subtitle: {
            text: 'Source: WorldClimate.com'
        },
        xAxis: {
            categories: [1519862400000, 1519948800000, 1520035200000, 1520121600000],
            labels: {
                formatter: function () {
                    return Highcharts.dateFormat("%b %e", this.value)
                }
            }
        },
        yAxis: {
            title: {
                text: 'Opady w [mm]'
            }
        },
        tooltip: {
            crosshairs: true,
            shared: true
        },
        plotOptions: {
            spline: {
                marker: {
                    radius: 4,
                    lineColor: '#666666',
                    lineWidth: 1
                }
            }
        },
        series: [{
            name: 'London',
            marker: {
                symbol: 'diamond'
            },
            data: [{
                y: 3.9,
                marker: {
                    symbol: 'url(https://www.highcharts.com/samples/graphics/snow.png)'
                }
            }, {
                    y: 4.2,
                    marker: {
                        symbol: 'url(https://www.highcharts.com/samples/graphics/snow.png)'
                    }
                },5.7, 8.5, 11.9, 15.2, 17.0, 16.6, 14.2, 10.3, 6.6, 4.8]
        }]
    });

    //ManyDaysCity visible
    Highcharts.chart('visible', {
        chart: {
            type: 'spline',
            scrollablePlotArea: {
                minWidth: 600,
                scrollPositionX: 1
            }
        },
        title: {
            text: 'Wind speed during two days'
        },
        subtitle: {
            text: '13th & 14th of February, 2018 at two locations in Vik i Sogn, Norway'
        },
        xAxis: {
            type: 'datetime',
            labels: {
                overflow: 'justify'
            }
        },
        yAxis: {
            title: {
                text: 'Wind speed (m/s)'
            },
            minorGridLineWidth: 0,
            gridLineWidth: 0,
            alternateGridColor: null,
            plotBands: [{ 
                from: 0,
                to: 0.8,
                color: 'rgba(68, 170, 213, 0.1)',
                label: {
                    text: 'Bardzo słaba',
                    style: {
                        color: '#606060'
                    }
                }
            }, {
                from: 0.8,
                to: 2.0,
                color: 'rgba(0, 0, 0, 0)',
                label: {
                    text: 'Słaba',
                    style: {
                        color: '#606060'
                    }
                }
            }, {
                from: 2.0,
                to: 5.0,
                color: 'rgba(68, 170, 213, 0.1)',
                label: {
                    text: 'Umiarkowana',
                    style: {
                        color: '#606060'
                    }
                }
            }, {
                from: 5,
                to: 10,
                color: 'rgba(0, 0, 0, 0)',
                label: {
                    text: 'dobra',
                    style: {
                        color: '#606060'
                    }
                }
            }, { // Fresh breeze
                from: 10,
                to: 999,
                color: 'rgba(68, 170, 213, 0.1)',
                label: {
                    text: 'bardzo dobra',
                    style: {
                        color: '#606060'
                    }
                }
            }]
        },
        tooltip: {
            valueSuffix: ' m/s'
        },
        plotOptions: {
            spline: {
                lineWidth: 4,
                states: {
                    hover: {
                        lineWidth: 5
                    }
                },
                marker: {
                    enabled: false
                },
                pointInterval: 3600000, // one hour
                pointStart: Date.UTC(2018, 1, 13, 0, 0, 0)
            }
        },
        series: [{
            name: 'Hestavollane',
            data: [
                3.7, 3.3, 3.9, 5.1, 3.5, 3.8, 4.0, 5.0, 6.1, 3.7, 3.3, 6.4,
                6.9, 6.0, 6.8, 4.4, 4.0, 3.8, 5.0, 4.9, 9.2, 9.6, 9.5, 6.3,
                9.5, 10.8, 14.0, 11.5, 10.0, 10.2, 10.3, 9.4, 8.9, 10.6, 10.5, 11.1,
                10.4, 10.7, 11.3, 10.2, 9.6, 10.2, 11.1, 10.8, 13.0, 12.5, 12.5, 11.3,
                10.1
            ]

        }, {
            name: 'Vik',
            data: [
                0.2, 0.1, 0.1, 0.1, 0.3, 0.2, 0.3, 0.1, 0.7, 0.3, 0.2, 0.2,
                0.3, 0.1, 0.3, 0.4, 0.3, 0.2, 0.3, 0.2, 0.4, 0.0, 0.9, 0.3,
                0.7, 1.1, 1.8, 1.2, 1.4, 1.2, 0.9, 0.8, 0.9, 0.2, 0.4, 1.2,
                0.3, 2.3, 1.0, 0.7, 1.0, 0.8, 2.0, 1.2, 1.4, 3.7, 2.1, 2.0,
                1.5
            ]
        }],
        navigation: {
            menuItemStyle: {
                fontSize: '10px'
            }
        }
    });
});