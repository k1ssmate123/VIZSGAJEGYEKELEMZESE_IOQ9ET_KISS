subjects = [];
async function downloadAndDisplay() {
    const response = await fetch('http://localhost:5065/')
    subjects = await response.json()
    console.log(subjects)

    document.querySelector('#subjects').innerHTML = '';
  
}


function addSubject()
{
    let subjectNameForm = document.getElementById('subject').value
    let marksList = document.getElementById('marks').value
   
    fetch('http://localhost:5065', {
        method: 'POST',
        headers: { 'Content-Type' : 'application/json', },
        body: JSON.stringify({
            subjectName: subjectNameForm,
            markList: marksList,
        })
    })
    .then(resp => {
        console.log('Response: ', resp)
        if (resp.status === 200) {
            window.location.href = "index.html";
            downloadAndDisplay();
        }
    })
    .catch(error => console.log(error))
}

