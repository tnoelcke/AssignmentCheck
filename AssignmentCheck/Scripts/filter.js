
//This function gets called when some one changes the value of the drop down box
//that changes the results to show all or invalid only.
function filter() {
    //get the value of the filter from the dom.
    let result = document.getElementById("Results_Filter");
    let resultText = result.Value;
    let showValid;
    //set up for our HTTP post later
    if (resultText === "Show All Results") {
        showValid = true;
    } else {
        showValid = false;
    }

    //get our URL todo an HTTP Post Later. add the paramater that states weather or not to show
    //valid results.
    var url = window.location.href;
    url.concat("/" + showValid.toString());


    //do the HTTP POST.
    var xhr = new XMLHttpRequest();
    xhr.open("POST", url, true);

    //handles the data once we get it back.
    xhr.onreadystatechange = function (data) {
        //finds the olds results and removes them.
        let parent = document.getElementById("results");
        let results = document.getElementsByClassName("remove-class");
        for (var i = 0; i < results.length; i++) {
            parent.removeChild(results[i]);
        }

        //add the filtered results to the dom.
        console.log(data.target.response);
        let target = document.getElementById("results");
        target.appendChild(data.target.response);
    }

    xhr.onerror = function (e) {
        console.log(e);
    }

    xhr.send();
}