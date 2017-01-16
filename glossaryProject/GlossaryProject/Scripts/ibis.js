var ibis = {
    layout: {},
    page: {
        handlers: {},
        startUp: null
    },
    services: {},
    ui: {
        notifications: {},
        startUp: null
    }
};


ibis.layout.startUp = function () {

    //this does a null check on ibis.page.startUp
    if (ibis.page.startUp) {
        console.log("ibis.page.startup");
        ibis.page.startUp();
    }
};
$(document).ready(ibis.layout.startUp);