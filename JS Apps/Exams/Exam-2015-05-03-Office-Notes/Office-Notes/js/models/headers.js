var app = app || {};

app.headers = (function () {
    function Headers(applicationId, restAPIKey) {
        this.appId = applicationId;
        this.restAPIKey = restAPIKey;
    }

    Headers.prototype.getHeaders = function (useSessionToken) {
        var headers = {
            'X-Parse-Application-Id': this.appId,
            'X-Parse-REST-API-Key': this.restAPIKey,
            'Content-Type': 'application/json'
        };

        if (useSessionToken) {
            headers['X-Parse-Session-Token'] = sessionStorage['sessionToken'];
        }

        return headers;
    };

    return {
        load: function (applicationId, restAPIKey) {
            return new Headers(applicationId, restAPIKey);
        }
    }
})();