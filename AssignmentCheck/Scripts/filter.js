
//This function gets called when some one changes the value of the drop down box
//that changes the results to show all or invalid only.
function filter() {
    //get the value of the filter from the dom.
    let result = document.getElementById("Results_Filter");
    let resultText = result.Value;
    var showValid;
    //set up for our HTTP post later
    if (resultText === "Show All") {
        let showValid = true;
    } else {
        let showValid = false;
    }

    //get our URL todo an HTTP Post Later. add the paramater that states weather or not to show
    //valid results.
    var url = URL.toString();
    url.concat("/" + showValid.toString());


    //do the HTTP POST.
    var xhr = new XMLHttpRequest();
    xhr.open('POST', url, true);

    //handles the data once we get it back.
    xhr.onreadystatechange = function (data) {
        //finds the olds results and removes them.
        let results = document.getElementsByClassName("list-group-item");
        for (var i = 0; i < results.length; i++) {
            results[i].remove();
        }

        //add the filtered results to the dom.
        let target = document.getElementById("results");
        target.appendChild(data);
    }

    xhr.onerror = function (e) {
        console.log(e);
    }


}