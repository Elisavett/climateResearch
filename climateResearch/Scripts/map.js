window.onload = function () {
    var json = document.getElementById('json').value;
    let observationPoints = JSON.parse(json);
    var isAuth = document.getElementById('authority') != null;

    //преобразую в число с плавающей точкой
    ymaps.ready(init);
    function init() {

        let max_lat = -90;
        let max_long = -180;
        let min_lat = 90;
        let min_long = 180;

        MyIconContentLayout = ymaps.templateLayoutFactory.createClass(
            '<div style="color: #000000; font-weight: bold; font-size: small">$[properties.iconContent]</div>'
        );

        for (let i = 0; i < observationPoints.length; i++) {
            if(observationPoints[i] !== undefined) {
                if (observationPoints[i].Latitude > max_lat) max_lat = observationPoints[i].Latitude;
                if (observationPoints[i].Latitude < min_lat) min_lat = observationPoints[i].Latitude;
                if (observationPoints[i].Longtitude > max_long) max_long = observationPoints[i].Longtitude;
                if (observationPoints[i].Longtitude < min_long) min_long = observationPoints[i].Longtitude;

            }
        }


        // Создание экземпляра карты и его привязка к контейнеру с
        // заданным id ("map").

        let delta = 2;
        let map = new ymaps.Map('map',
            {
            bounds: [[min_lat - delta, min_long - delta], [max_lat + delta, max_long + delta]],
            center: [(min_lat+max_lat)/2, (min_long+max_long)/2],
            controls: ['zoomControl']
        }, {
            minZoom: 1,
            maxZoom: 16,
            maxAnimationZoomDifference: 1,
            avoidFractionalZoom: false
        });
        for (let i = 0; i < observationPoints.length; i++) {
            if (observationPoints[i] !== undefined) {
                let authAdditionalParams = isAuth ? "<a target='_blank' href='/admin/editCoordinates/" + observationPoints[i].id + "'>Редактировать координаты</a>" : "";
                var myCircle = new ymaps.Placemark(
                    [observationPoints[i].Latitude, observationPoints[i].Longtitude],

                    {
                        // Содержимое балуна. //
                        balloonContentBody:
                            " Пункт наблюдения: " + observationPoints[i].Name + "<br \/>" +
                            " Координаты: ш: " + observationPoints[i].Latitude + "; д: " + observationPoints[i].Longtitude + "<br \/>" +

                            "<a target='_blank' href='/getObservationPointById?id=" + parseInt(observationPoints[i].id) + "'>Ифнормация о пункте</a>" + "<br \/>" +
                            authAdditionalParams,
                        iconContent: observationPoints[i].MeasuredValue
                    }, {
                        preset: "islands#redStretchyIcon",
                        iconContentLayout: MyIconContentLayout

                    });

                // Добавляем круг на карту.
                map.geoObjects.add(myCircle);
            }
        }

    }

}