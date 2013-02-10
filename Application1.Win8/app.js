
$(function() {
    
    Application1.app = new DevExpress.framework.html.HtmlApplication({
        ns: Application1,
        viewPortNode: document.getElementById("viewPort"),
        defaultLayout: Application1.config.defaultLayout,
        navigation: Application1.config.navigation
    });

    Application1.app.router.register(":view/:id", { view: "Index", id: undefined });
});
