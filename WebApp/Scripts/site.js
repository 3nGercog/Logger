$(document).on("ready", function () {
    console.log("document ready");
});
$(window).on("load", function () {
    console.log("window load");
    if(hst != undefined || hst != null) {
        creareCharts();
    }
});
$('input[type=button]').on('click', function (e) {
    var x = $('input[name=X]').val();
    var y = $('input[name=Y]').val();
    console.log('x -> ' + x + '   y -> ' + y);
});

function creareCharts() {

    if (!hst || hst.length === 0) {
        $('#box').removeClass('jxgbox');
        return;
    }
    // get random color
    //create text
    //create graf
    var board = JXG.JSXGraph.initBoard('box', { boundingbox: [-max, max, max, -max ], grid: true });
    //var board = JXG.JSXGraph.initBoard('box', { boundingbox: [-5, 50, 50, -5 ], grid: true });
    var sortArr = [];
    var col = '#027f81';
    var p, pnext;
    var isFirst = true;
    for (var a = 0; a < hst.length; a++) {
        p = board.createElement('point', [hst[a].X, hst[a].Y], { size: 3, withLabel: true, fixed: true });
        if (pnext != p) {
            if (!isFirst) {
                board.create('line', [pnext, p], { straightFirst: false, straightLast: false, strokeColor: col });
            }
            pnext = p;
            if (isFinite) { isFirst = false; }
        }
    }
}


