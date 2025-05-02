subjects = [];
async function downloadAndDisplay() {
    const response = await fetch('http://localhost:5186/ExamMarks/')
    subjects = await response.json()
    console.log(subjects)

    document.querySelector('#tb').innerHTML = '';
    subjects.map(x=>{
        let tr = document.createElement('tr')
        let tdName = document.createElement('td')
        let tdMarks = document.createElement('td')
       

        
        tdName.innerHTML = x.subjectName
        tdMarks.innerHTML = x.marks
    
        tr.appendChild(tdName)
        tr.appendChild(tdMarks)
        document.querySelector('#tb').appendChild(tr)
    })
}


function addSubject()
{
    let subjectNameForm = document.getElementById('subject').value
    let marksList = document.getElementById('marks').value
   
    fetch('http://localhost:5186/ExamMarks/', {
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

