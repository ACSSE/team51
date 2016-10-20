(function (app) {
	'use strict';

	app.directive('adnavBar', adnavBar);

	function adnavBar() {
		return {
			restrict: 'E',
			replace: true,
			templateUrl: '/scripts/spa/layout/adnavBar.html'
		}
	}

})(angular.module('common.ui'));