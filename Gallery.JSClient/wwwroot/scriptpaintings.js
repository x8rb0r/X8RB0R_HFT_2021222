let paintings = [];
let connection = null;

getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:26918/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on
        (
            "PaintingCreated", (user, message) => {
                getdata();
        });
    connection.on
        (
            "PaintingDeleted", (user, message) => {
                getdata();
        });
    connection.on
        (
            "PaintingUpdated", (user, message) => {
                getdata();
            });

    connection.onclose
        (async () => {
            await start();
        });
    start();

}

async function getdata() {
    await fetch('http://localhost:26918/Painting/')
        .then(x => x.json())
        .then(y => {
            paintings = y;
            console.log(paintings);
            display();
        });
   
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};



function display() {
    document.getElementById('resultarea').innerHTML = "";
    paintings.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            
            "</td><td>" + t.title + "</td><td>" + t.painter + "</td><td>" + t.condition + "</td><td>" + t.value + "</td><td>" + t.yearPainted + "</td><td>" + `<button type ="button" onclick="remove(${t.paintingId})">Delete` + "</td></tr>";
        
    });
}


function remove(id) {
    fetch('http://localhost:26918/Painting/'+ id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });

}
function update() {
    let title = document.getElementById('paintingtitle').value;
    let painter = document.getElementById('paintingpainter').value;
    let condition = document.getElementById('paintingcondition').value;
    let value = document.getElementById('paintingvalue').value;
    let yearpainted = document.getElementById('paintingyearpainted').value;
    let paintingid = document.getElementById('paintingid_input').value;

    fetch('http://localhost:26918/Painting/', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                PaintingId: paintingid,
                Title: title,
                Painter: painter,
                Condition: condition,
                Value: value,
                YearPainted: yearpainted
            })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let title = document.getElementById('paintingtitle').value;
    let painter = document.getElementById('paintingpainter').value;
    let condition = document.getElementById('paintingcondition').value;
    let value = document.getElementById('paintingvalue').value;
    let yearpainted = document.getElementById('paintingyearpainted').value;
    fetch('http://localhost:26918/Painting/', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                Title: title,
                Painter: painter,
                Condition: condition,
                Value: value,
                YearPainted: yearpainted

            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });

}


