$(document).ready(() => {
    $(document).on("click", ".delete-product", function (e) {
        e.preventDefault();
        var id = $(this).siblings(".product-id").val();
        debugger;
        sendData(id);
    })
 })


function sendData(id) {
    
    fetch('/AdminPlatform/ProductDelete?id=' + id, {
        method: 'GET',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.json())
        .then(response => console.log(JSON.stringify(response)))
}