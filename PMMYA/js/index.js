
$(document).ready(function ($) {

    $.noConflict();
    $('.weather1').weather({
        city: 'Mumbai, IN',
        tempUnit: 'C',
        displayDescription: true,
        displayMinMaxTemp: true,
        //displayWind: true,
        //displayHumidity: true
    });

    $('.weather2').weather({
        city: 'Aurangabad , IN',     
    	tempUnit: 'C',
    	displayDescription: true,
    	displayMinMaxTemp: true,
    	//displayWind: true,
    	//displayHumidity: true
    });

    $('.weather3').weather({
        city: 'Nagpur, IN',
        tempUnit: 'C',
        displayDescription: true,
        displayMinMaxTemp: true,
        //displayWind: true,
        //displayHumidity: true
    });

    $('.weather4').weather({
        city: 'Mecca, SA',
        tempUnit: 'C',
        displayDescription: true,
        displayMinMaxTemp: true,
        //displayWind: true,
        //displayHumidity: true
    });

    $('.weather5').weather({
        city: 'Medina, SA',
        tempUnit: 'C',
        displayDescription: true,
        displayMinMaxTemp: true,
        //displayWind: true,
        //displayHumidity: true
    });
});