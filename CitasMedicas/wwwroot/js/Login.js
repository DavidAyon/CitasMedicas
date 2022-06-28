
window.fbAsyncInit = function () {
    debugger;
    FB.init({
        appId: '368371445219466',
        cookie: true,
        xfbml: true,
        version: 'v14.0'
    });
    FB.getLoginStatus(function (response) {
        statusChangeCallback(response);
        
    });
    FB.AppEvents.logPageView();

};

(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement(s); js.id = id;
    js.src = "https://connect.facebook.net/en_US/sdk.js";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));

function checkLoginState() {
    FB.getLoginStatus(function (response) {
        statusChangeCallback(response);
    });
}

function testAPI() {
    console.log('Welcome!  Fetching your information.... ');
    FB.api('/me', function (response) {
        console.log('Successful login for: ' + response.name);
            result2 = $.ajax({
                type: 'GET',
                url: "/Home/Redireccion",
                data: { clave: response.name, userId: response.id },
                success: function (res) {
                    var url = '@Url.Action("CrearCita", "Cita")';
                    window.location.href = '/Cita/CrearCita';
                }
            });
    });

    
}

function statusChangeCallback(response) {
    console.log('statusChangeCallback');
    console.log(response);
    // The response object is returned with a status field that lets the
    // app know the current login status of the person.
    // Full docs on the response object can be found in the documentation
    // for FB.getLoginStatus().
    if (response.status === 'connected') {
        // Logged into your app and Facebook.
        testAPI();
    } else {
    }
}