$(document).ready(init());
function init() {
    ymaps.ready(function () {
        var map = new ymaps.Map("map", {
            center: [54.876674, 28.689605],
            zoom: 50
        }, {
            searchControlProvider: 'yandex#search'
        });
    });
};
