const inputs = document.querySelectorAll(".input");


function addcl(){
	let parent = this.parentNode.parentNode;
	parent.classList.add("focus");
}

function remcl(){
	let parent = this.parentNode.parentNode;
	if(this.value == ""){
		parent.classList.remove("focus");
	}
}


inputs.forEach(input => {
	input.addEventListener("focus", addcl);
	input.addEventListener("blur", remcl);
});


document.addEventListener("DOMContentLoaded", function () {
    var boxycht = document.getElementById("box_ttpm_nhap_kho");
    var ychtButtonsssx = document.getElementById("btn_plus");
    var closeButton1 = document.getElementById("btn_dong");

    boxycht.style.display = "none";

    ychtButtonsssx.addEventListener("click", function () {
        if (boxycht.style.display === "none") {
            boxycht.style.display = "block";
        } else {
            boxycht.style.display = "none";
        }
    });

    closeButton1.addEventListener("click", function () {
        boxycht.style.display = "none";
    });
});
