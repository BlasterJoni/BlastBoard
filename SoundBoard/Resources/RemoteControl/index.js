function processLayoutMessage(a){
    /*Update Layouts*/
    var layoutSelect = document.getElementById("layouts")
    //Remove all layouts, if any
    while(layoutSelect.firstChild){
        layoutSelect.removeChild(layoutSelect.firstChild);
    }
    //Add the layouts
    for (var i=0 ; i<a.layoutList.length ;  i++){
        var layoutToAdd = document.createElement("option");
        layoutToAdd.value = i;
        layoutToAdd.innerText = a.layoutList[i];
        layoutSelect.appendChild(layoutToAdd);
        //Select the current layout
        if (a.layoutList[i] == a.currentLayout) layoutSelect.value = i;
    }
    /*Update Buttons*/
    var buttonDiv = document.getElementById("buttons");
    //Remove all buttons, if any
    while(buttonDiv.firstChild){
        buttonDiv.removeChild(buttonDiv.firstChild);
    }
    //Add the buttons
    for (var i=0 ; i<a.buttons.length ; i++){
        var buttonToAdd = document.createElement("button");

        if (a.buttons[i].image != ""){
            image = document.createElement("img");
            image.src="data:image;base64," + a.buttons[i].image;
            buttonToAdd.appendChild(image);
        }

        textDiv = document.createElement("div");
        textDiv.innerText=a.buttons[i].text;
        buttonToAdd.appendChild(textDiv);
        buttonToAdd.style.color = a.buttons[i].color;
        
        if (a.buttons[i].image=="") textDiv.style.marginLeft = "0px";

        if (a.buttons[i].background != ""){
            buttonToAdd.style.backgroundImage = "url('data:image;base64,"+a.buttons[i].background+"')";
        }

        buttonToAdd.id = i;

        buttonToAdd.onclick = function() {
            buttonMessage = { message : this.id };
            buttonMessage = JSON.stringify(buttonMessage);
            s.send(buttonMessage);
        };

        buttonDiv.appendChild(buttonToAdd);
    }
}

function processAudioMessage(a){
    document.getElementById("localCheck").checked = a.local;
    document.getElementById("localVolumeBar").value = a.localVolume;
    document.getElementById("linkCheck").checked = a.link;
    document.getElementById("outputCheck").checked = a.output;
    document.getElementById("outputVolumeBar").value = a.outputVolume;
}



function StopSound(){
    stopMessage = {message:"stop"};
    stopMessage = JSON.stringify(stopMessage);
    s.send(stopMessage);
}

function AudioChanged(id = null){
    if (id == "localVolumeBar" && document.getElementById("linkCheck").checked){
        document.getElementById("outputVolumeBar").value = document.getElementById("localVolumeBar").value;
    }
    if (id == "outputVolumeBar" && document.getElementById("linkCheck").checked){
        document.getElementById("localVolumeBar").value = document.getElementById("outputVolumeBar").value;
    }
    audioMessage = {message:"audio",
                    data:{
                        audio:{
                            local: document.getElementById("localCheck").checked,
                            localVolume: document.getElementById("localVolumeBar").value,
                            link: document.getElementById("linkCheck").checked,
                            output: document.getElementById("outputCheck").checked,
                            outputVolume: document.getElementById("outputVolumeBar").value
                        }
                    }
                    };
    audioMessage = JSON.stringify(audioMessage);
    s.send(audioMessage);
}

function LayoutChanged(){
    layoutMessage = {message:"layout",
                    data:{
                        layout:{
                            currentLayout: document.getElementById("layouts").options[document.getElementById("layouts").value].innerText
                        }
                    }
                    };
    layoutMessage = JSON.stringify(layoutMessage);
    s.send(layoutMessage);
}



var ip = "";
if (window.location.hash==""){
    ip = prompt("Please enter the soundboard's ip address", "localhost:42069");
    if (ip == null || ip == "") {
       ip = "localhost:42069" 
    }
}
else{
    ip = window.location.hash.substr(1);
}

var s = new WebSocket("ws://"+ip)

s.onmessage = (e) => {
    SoundBoardInfo = JSON.parse(e.data);
    if (SoundBoardInfo.message == "full"){
        processAudioMessage(SoundBoardInfo.data.audio);
        processLayoutMessage(SoundBoardInfo.data.layout);
    }
    if (SoundBoardInfo.message == "audio"){
        processAudioMessage(SoundBoardInfo.data.audio);
    }
    if (SoundBoardInfo.message == "layout"){
        processLayoutMessage(SoundBoardInfo.data.layout);
    }
}

s.onopen = () => { 
    messageToSend = JSON.stringify({message:"full"});
    s.send(messageToSend);
}