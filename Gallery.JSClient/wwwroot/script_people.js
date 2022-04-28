let people = [];
let connection = null;


setupSignalR();
getdata();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:26918/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on
        (
            "PersonCreated", (user, message) => {
                getdata();
        });
    connection.on
        (
            "PersonDeleted", (user, message) => {
                getdata();
        });
    connection.on
        (
            "PersonUpdated", (user, message) => {
                getdata();
            });

    connection.onclose
        (async () => {
            await start();
        });
    start();

}

async function getdata() {
    await fetch('http://localhost:26918/Person/')
        .then(x => x.json())
        .then(y => {
            people = y;
            console.log(people);
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
    people.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            
            "</td><td>" + t.name + "</td><td>" + t.phoneNumber + "</td><td>" + t.email + "</td><td>" + t.birthYear + "</td><td>" + t.zipCode + "</td><td>" + `<button type ="button" onclick="remove(${t.personId})">Delete` + "</td></tr>";
        
    });
}


function remove(id) {
    fetch('http://localhost:26918/Person/'+ id, {
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
    let name = document.getElementById('personname').value;
    let phone = document.getElementById('personphonenumber').value;
    let email = document.getElementById('personemail').value;
    let birthyear = document.getElementById('personbirthyear').value;
    let zipcode = document.getElementById('personzipcode').value;
    let personid = document.getElementById('personid_input').value;

    fetch('http://localhost:26918/Person/', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                PersonId: personid,
                Name: name,
                PhoneNumber: phone,
                Email: email,
                BirthYear: birthyear,
                ZipCode: zipcode
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
    let name = document.getElementById('personname').value;
    let phone = document.getElementById('personphonenumber').value;
    let email = document.getElementById('personemail').value;
    let birthyear = document.getElementById('personbirthyear').value;
    let zipcode = document.getElementById('personzipcode').value;
    let personid = document.getElementById('personid_input').value;
    fetch('http://localhost:26918/Person/', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                Name: name,
                PhoneNumber: phone,
                Email: email,
                BirthYear: birthyear,
                ZipCode: zipcode

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


