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
        let tdBttns = document.createElement('td')
       
        tdName.innerHTML = x.subjectName
        tdMarks.innerHTML = x.marks

        let btnStats = document.createElement('button')
        btnStats.classList.add('btn')
        btnStats.classList.add('btn-sm')
        btnStats.classList.add('btn-warning')
        btnStats.classList.add('mx-2')
        btnStats.innerHTML = 'Statisztikák'
        btnStats.idParameter = x.id
        btnStats.addEventListener('click', showStats)
        tdBttns.appendChild(btnStats)  
        


        let btnDel = document.createElement('button')
        btnDel.classList.add('btn')
        btnDel.classList.add('btn-sm')
        btnDel.classList.add('btn-danger')
        btnDel.classList.add('mx-2')
        btnDel.innerHTML = 'X'
        btnDel.idParameter = x.id
        btnDel.addEventListener('click', deleteSubject)
        tdBttns.appendChild(btnDel)  
        


        tr.appendChild(tdName)
        tr.appendChild(tdMarks)
        tr.appendChild(tdBttns)
        document.querySelector('#tb').appendChild(tr)
    })
}

async function showStats(event)
{
    const response = await fetch('http://localhost:5186/ExamMarks/stats/'+event.target.idParameter)
    stats = await response.json()
    console.log(stats)
    distributionDiagram(stats.distribution)
}



function distributionDiagram(distribution)
{
const container = document.getElementById("chart");
const maxCount = Math.max(...Object.values(distribution));

for (const grade of Object.keys(distribution)){
  const count = distribution[grade];

  const bar = document.createElement("div");
  bar.classList.add("bar");
  bar.style.height = `${(count / maxCount) * 100}%`;  //Barok magassága


  const value = document.createElement("div");
 
  value.textContent = count; //Barban szövegként az értéke

  const label = document.createElement("div");
  label.className = "bar-label";
  label.textContent = grade; //Bar alatt hányas jegy

  bar.appendChild(value);
  bar.appendChild(label);
  container.appendChild(bar);
}
}


function deleteSubject(event)
{
    fetch('http://localhost:5186/ExamMarks/' + event.target.idParameter, {
        method: 'DELETE',
        headers: { 'Content-Type' : 'application/json', },
        body: null
    })
    .then(resp => {
        console.log('Response: ', resp)
        if (resp.status === 200) {
            downloadAndDisplay()
        }
    })
}

function addSubject()
{
    let subjectNameForm = document.getElementById('subject').value
    let marksList = document.getElementById("marks").value.split(';').map(m => parseInt(m.trim()));

   
    fetch('http://localhost:5186/ExamMarks/', {
        method: 'POST',
        headers: { 'Content-Type' : 'application/json', },
        body: JSON.stringify({
            subjectName: subjectNameForm,
            marks: marksList,
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

