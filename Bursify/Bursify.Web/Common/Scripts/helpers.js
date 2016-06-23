var App = App || {};
(function () {

    var appLocalizationSource = abp.localization.getSource('Bursify');
    App.localize = function () {
        return appLocalizationSource.apply(this, arguments);
    };

})(App);