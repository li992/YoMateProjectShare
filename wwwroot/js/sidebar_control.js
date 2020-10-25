/* Set the width of the side navigation to 250px and the left margin of the page content to 250px and add a black background color to body */
function openNav() {
    document.getElementById("leftNav").style.width = "250px";
    document.body.style.backgroundColor = "rgba(0,0,0,0.4)";
    document.getElementById("leftNavControlBtn").style.visibility = "hidden";
    document.getElementById("topNav").style.backgroundColor = "rgba(0,0,0,0.4)";
}

/* Set the width of the side navigation to 0 and the left margin of the page content to 0, and the background color of body to white */
function closeNav() {
    document.getElementById("leftNav").style.width = "0";
    document.body.style.backgroundColor = "white";
    document.getElementById("leftNavControlBtn").style.visibility = "visible";
    document.getElementById("topNav").style.backgroundColor = "white";
}
