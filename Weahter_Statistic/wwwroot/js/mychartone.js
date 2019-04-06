var arrayRiseSet, arrayPressure, arrayHum, arrayClo, arrayTempRange, arrayTempAvg, arrayRain, arrayVis, arrayWind,results;

DeclareArray();
FillArray();

function DeclareArray() {
    arrayRiseSet = new Array(arrayInfo.length);
    arrayPressure = new Array(arrayInfo.length);
    arrayHum = new Array(arrayInfo.length);
    arrayClo = new Array(arrayInfo.length);
    arrayTempRange = new Array(arrayInfo.length);
    arrayTempAvg = new Array(arrayInfo.length);
    arrayRain = new Array(arrayInfo.length);
    arrayVis = new Array(arrayInfo.length);
    arrayWind = new Array(arrayInfo.length);
    results = [];
}
function FillArray() {
    if (arrayInfo != null) {
        for (let i = 0; i < arrayInfo.length; i++) {
            arrayRiseSet[i] = new Array(2);
            arrayRiseSet[i][0] = SetTime(arrayInfo[i].sunriseTime);
            arrayRiseSet[i][1] = SetTime(arrayInfo[i].sunsetTime);

            arrayPressure[i] = arrayInfo[i].pressure;
            arrayHum[i] = arrayInfo[i].humadity;
            arrayClo[i] = arrayInfo[i].cloudy;

            arrayTempRange[i] = new Array(2);
            arrayTempRange[i][0] = arrayInfo[i].minTemp;
            arrayTempRange[i][1] = arrayInfo[i].maxTemp;
            arrayTempAvg[i] = Math.round((arrayInfo[i].maxTemp + arrayInfo[i].minTemp) / 2);
            arrayVis[i] = arrayInfo[i].visible;

            arrayWind[i] = new Array(2);
            arrayWind[i][0] = arrayInfo[i].windspeed;
            arrayWind[i][1] = arrayInfo[i].directNumber;

            //https://www.base64-image.de/

            // check https://www.iconfinder.com/iconsets/weather-29
            if (arrayInfo[i].typeWeat == "snow") {
                results.push({
                    y: arrayInfo[i].rainfall,
                    marker: {
                        symbol: 'url(data:image/png;base64,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)'
                    }
                });
            }
            else if (arrayInfo[i].typeWeat == "rain") {
                results.push({
                    y: arrayInfo[i].rainfall,
                    marker: {
                        symbol: 'url(data:image/png;base64,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)'
                    }
                });
            }
            else {
                results.push({
                    y: arrayInfo[i].rainfall,
                    marker: {
                        symbol: 'square'
                    }
                });
            }

        }

    }

    
}

function SetTime(array) {
    var date = Date.UTC(2019, 0, 1, array[0], array[1], array[2])
    return date;
}

var subtitleTxt = 'Dane od ' + arrayDate[0] + ' do ' + arrayDate[arrayDate.length - 1];
var city = arrayInfo[0].place;

$(document).ready(function () {

    // ManyDaysCity sun
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
            tickInterval: 3600*1000,
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
            text: subtitleTxt
        },
        xAxis: {
            categories: arrayDate
        },
        yAxis: {
            title: {
                text: 'Ciśnienie [hPa]'
            },
            min: 950,
            max:1060
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
            type: 'area',
            name: 'hPa',
            data: arrayPressure      
        }]
    });

    // ManyDaysCity humidity
    Highcharts.chart('humidity', {
        chart: {
            type: 'column'
        },
        title: {
            text: 'Poziom wilgotności'
        },
        subtitle: {
            text: subtitleTxt
        },
        xAxis: {
            categories: arrayDate,
            title: {
                text: null
            },
            
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
            valueSuffix: '{y}%'
        },
        plotOptions: {
            bar: {
                dataLabels: {
                    enabled: true,
                    format: '{y}%'
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
            name: city,
            data: arrayHum
        }]
    });

    // ManyDaysCity cloudy
    Highcharts.chart('cloudy', {
        chart: {
            type: 'column'
        },
        title: {
            text: 'Poziom zachmurzenia'
        },
        subtitle: {
            text: subtitleTxt
        },
        xAxis: {
            categories: arrayDate,
            title: {
                text: null
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
                overflow: 'justify',
            }
        },
        tooltip: {
            valueSuffix: ' %'
        },
        plotOptions: {
            bar: {
                dataLabels: {
                    enabled: true,
                    format: '{y}%'
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
            name: city,
            data: arrayClo
        }]
    });

    //ManyDaysCity temperatures
    Highcharts.chart('temperatures', {

        title: {
            text: 'Temperatury'
        },

        xAxis: {
            categories: arrayDate,
            title: {
                text: null
            }
        },

        yAxis: {
            title: {
                text: 'Temperatura [st.C]'
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
            name: 'średnia temperatura',
            data: arrayTempAvg,
            zIndex: 1,
            marker: {
                fillColor: 'white',
                lineWidth: 2,
                lineColor: Highcharts.getOptions().colors[0]
            }
        }, {
            name: 'Zakres',
            data: arrayTempRange,
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
            categories: arrayDate
            
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
            name: city,
            marker: {
                symbol: 'diamond'
            },
            data: results
        }]
    });

    //ManyDaysCity wind
    Highcharts.chart('windchart', {
        chart: {
            type: 'windbarb'

        },
        title: {
            text: 'Prekość wiatru'
        },
        subtitle: {
            text: subtitleTxt
        },
        xAxis: {
            type: 'datetime',
            offset: 40,
            categories: arrayDate
        },
        yAxis: {
            title: {
                text: 'Predkość wiatru [km/h]'
            }
        },
        series: [{
            data: arrayWind,
            name: 'Wiatr',
            color: Highcharts.getOptions().colors[1],
            showInLegend: false,
            tooltip: {
                valueSuffix: ' m/s'
            }
        }, {
            type: 'area',
            keys: ['y', 'rotation'], // rotation is not used here
            data: arrayWind,
            name: 'Prędkość wiatru',
            tooltip: {
                valueSuffix: ' m/s'
            }
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
            text: 'Widoczność'
        },
        subtitle: {
            text: subtitleTxt
        },
        xAxis: {
            categories: arrayDate,
            labels: {
                overflow: 'justify'
            }
        },
        yAxis: {
            title: {
                text: 'Widoczność w [km]'
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
                }],
            min:0,
        },
        tooltip: {
            valueSuffix: 'km'
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
            }
        },
        series: [{
            name: city,
            data: arrayVis

        }],
        navigation: {
            menuItemStyle: {
                fontSize: '10px'
            }
        }
    });

});