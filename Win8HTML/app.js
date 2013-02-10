window.Win8HTML = window.Win8HTML || {};

$(function() {
    app = new DevExpress.framework.html.HtmlApplication({
        ns: Win8HTML,
        viewPortNode: document.getElementById("viewPort"),
        defaultLayout: Win8HTML.config.defaultLayout,
        navigation: Win8HTML.config.navigation
    });
    app.router.register(":view/:id", { view: "Index", id: undefined });
});
