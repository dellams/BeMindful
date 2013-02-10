
// NOTE object below must be a valid JSON
window.Application1 = $.extend(true, window.Application1, {
    "config": {
        "endpoints": {
            "db": {
                "local": "",
                "production": ""
            }
        },
        "services": {
            "db": {
                "entities": {
                }
            }
        }
    }
});
