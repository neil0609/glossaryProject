if (!ibis.services.glossary) {
    ibis.services.glossary = {};
}

ibis.services.glossary.getGlossaryItem = function(id, onSuccess, onError){
    
    var url = "/api/glossary/" + id;

    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        success: onSuccess,
        error: onError,
        type: 'GET'
    }

    $.ajax(url, settings);

}

ibis.services.glossary.insertGlossaryItem = function (myData, onSuccess, onError) {

    var url = "/api/glossary";
    
    var settings = {
        cache : false,
        contentType : "application/x-www-form-urlencoded; charset=UTF-8",
        data : myData,
        dataType: 'json',
        success: onSuccess,
        error: onError,
        type: 'POST'
    }

    $.ajax(url, settings);

}

ibis.services.glossary.updateGlossaryItem = function (myData, onSuccess, onError) {

    var url = "/api/glossary/" + myData.id;

    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        data: myData,
        dataType: 'json',
        success: onSuccess,
        error: onError,
        type: 'PUT'
    }

    $.ajax(url, settings);

}

ibis.services.glossary.getGlossaryList = function (onSuccess, onError) {

    var url = "/api/glossary";

    var settings = {
        cache : false,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        success: onSuccess,
        error: onerror,
        type: 'GET'
    }

    $.ajax(url, settings);

}

ibis.services.glossary.deleteGlossaryItem = function (id, onSuccess, onError) {

    var url = "/api/glossary/" + id;

    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        success: onSuccess,
        error: onError,
        type: 'DELETE'
    }

    $.ajax(url, settings);

}