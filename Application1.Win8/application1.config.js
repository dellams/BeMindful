
// NOTE object below must be a valid JSON
window.Application1 = $.extend(true, window.Application1, {
    "config": {
        "defaultLayout": "split",
        "navigation": [
            {
                title: "Home",
                action: "#Index",
                icon: "home"
            },
            {
                title: "About",
                action: "#About",
                icon: "info",
                clearHistory: false
            }
        ]
    }
});
