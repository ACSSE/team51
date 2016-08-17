(function (app) {
	'use strict';

	app.directive('spnavBar', spnavBar);

	function spnavBar() {
		return {
			restrict: 'E',
			replace: true,
			templateUrl: '/scripts/spa/layout/spnavBar.html'
		}
	}

})(angular.module('common.ui'));