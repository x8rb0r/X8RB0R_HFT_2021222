let paintings = [];
let gmail = [];
let paintings2 = [];

getdata();



async function getdata() {
    await fetch('http://localhost:26918/NonCRUD/MostExpensivePaintingandItsExhibit')
        .then(x => x.json())
        .then(y => {
            paintings = y;
            display();
        });
    fetch('http://localhost:26918/NonCRUD/GmailUsers')
        .then(x => x.json())
        .then(y => {
            gmail = y;
            display1();
        });
    fetch('http://localhost:26918/NonCRUD/ExhibitsCountPaintings')
        .then(x => x.json())
        .then(y => {
            paintings2 = y;
            display2();
        });

}


function display() {
    document.getElementById('noncrud').innerHTML = "";
    paintings.forEach(t => {
        document.getElementById('noncrud').innerHTML +=
            "<p>Painting: " + t.painting + ", Exhibit: " + t.exhibit;
        console.log(paintings)
    });
}
function display1() {
    document.getElementById('noncrud1').innerHTML = "";
    gmail.forEach(t => {
        document.getElementById('noncrud1').innerHTML +=
            "<p>Name: " + t.name + ", Email: " + t.email;
        console.log(gmail)
    });
}
function display2() {
    document.getElementById('noncrud2').innerHTML = "";
    paintings2.forEach(t => {
        document.getElementById('noncrud2').innerHTML +=
            "<p>Exhibit: " + t.exhibit + ", Number of paintings: " + t.numbeR_OF_PAINTINGS;
        console.log(paintings2)
    });
}