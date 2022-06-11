'use strict';
/** 
  * Add several features to panels.  
*/
baseModule
    .directive('ctPaneltool', function () {
    var templates = {
        /* jshint multistr: true */
        collapse: "<div panel-collapse='' ng-click='{{panelId}} = !{{panelId}}' ng-init='{{panelId}}=false'>" + "<i ng-if='{{panelId}}' class='mdi mdi-arrow-down-drop-circle-outline'  tooltip-placement='auto left' uib-tooltip='Collapse'></i>" + "<i ng-if='!{{panelId}}' class='mdi mdi-arrow-up-drop-circle-outline' tooltip-placement='auto left' uib-tooltip='Collapse'></i>" + "</div>",
        dismiss: "<a href='#' class='btn btn-transparent btn-sm' panel-dismiss='' tooltip-placement='top' uib-tooltip='Close' ng-click='{{dismissFunction}}'>" + "<i class='ti-close'></i>" + "</a>",
        refresh: "<a href='#' class='btn btn-transparent btn-sm' panel-refresh='' tooltip-placement='top' uib-tooltip='Refresh' data-spinner='{{spinner}}'>" + "<i class='ti-reload'></i>" + "</a>"
    };

    return {
        restrict: 'E',
        template: function (elem, attrs) {
            var temp = '';
            if (attrs.toolCollapse)
                temp += templates.collapse.replace(/{{panelId}}/g, (elem.parent().parent().attr('id')));
            if (attrs.toolDismiss) {
                temp += templates.dismiss.replace(/{{dismissFunction}}/g, attrs.toolDismiss);
            }
            if (attrs.toolRefresh)
                temp += templates.refresh.replace(/{{spinner}}/g, attrs.toolRefresh);
            return temp;
        }
    };
});
baseModule
    .directive('panelDismiss', function () {
    'use strict';
    return {
        restrict: 'A',
        controller: ["$scope", "$element", function ($scope, $element) {
            var removeEvent = 'panel-remove', removedEvent = 'panel-removed';

            $element.on('click', function () {

                var parent = $(this).closest('.panel');

                destroyPanel();

                function destroyPanel() {
                    var col = parent.parent();
                    parent.fadeOut(300, function () {
                        $(this).remove();
                        if (col.is('[class*="col-"]') && col.children('*').length === 0) {
                            col.remove();
                        }
                    });
                }

            });
        }]
    };
})

    .directive('panelRefresh', function () {
        'use strict';

        return {
            restrict: 'A',
            controller: ["$scope", "$element", "$rootScope", function ($scope, $element, $rootScope) {
                var refreshEvent = 'panel-refresh', csspinnerClass = 'csspinner', defaultSpinner = 'load1';
                // method to clear the spinner when done
                //function removeSpinner() {
                //    this.removeClass(csspinnerClass);
                //}
                //catchEvent to refresh
                var id = $element.attr('id');

                if (id != undefined) {
                    $rootScope.$on(id + 'RefreshStart', function (e) {
                        startRefresh(id);
                    });

                    $rootScope.$on(id + 'RefreshEnd', function (e) {
                        //console.log(id + 'RefreshEnd');
                        var concernedElement = $("#" + id + ".panel");
                        concernedElement.removeClass(csspinnerClass);
                    });
                }
                // catch clicks to toggle panel refresh
                $element.on('click', function () {
                    startRefresh(id);
                });

                function startRefresh(idElement) {
                    //console.log(idElement);
                    var concernedElement = $("#" + idElement + ".panel");
                    var elementForDetails = $("a#" + id)
                    var panel = concernedElement, spinner = elementForDetails.data('spinner') || defaultSpinner;

                    // start showing the spinner
                    panel.addClass(csspinnerClass + ' ' + spinner);

                    // attach as public method
                    //panel.removeSpinner = removeSpinner;

                    // Trigger the event and send the panel object
                    //$this.trigger(refreshEvent, [panel]);
                }

            }]
        };
    });

//(function ($, window, document) {
//    'use strict';

//    $(document).on('panel-refresh', '.panel', function (e, panel) {

//        // perform any action when a .panel triggers a the refresh event
//        //setTimeout(function () {
//        //    // when the action is done, just remove the spinner class
//        //    panel.removeSpinner();
//        //}, 3000);

//    });

//}(jQuery, window, document));