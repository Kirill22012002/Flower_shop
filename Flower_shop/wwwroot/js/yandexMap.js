ymaps.ready(init);

function init() {
    var myMap = new ymaps.Map("map", {
        center: [54.876674, 28.689605],
        zoom: 17
    }, {
        searchControlProvider: 'yandex#search'
    });

    myMap.geoObjects
        .add(new ymaps.Placemark([54.876674, 28.689605], {
            balloonContent: 'Цветы и подарки'
        }, {
            preset: 'islands#redDotIcon'
        }));
}
