subjects = [];
async function downloadAndDisplay() {
    const response = await fetch('http://localhost:5186/ExamMarks/')
    subjects = await response.json()
    console.log(subjects)

    document.querySelector('#tb').innerHTML = '';
    subjects.map(x => {
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

async function getStats(id){
    const response = await fetch('http://localhost:5186/ExamMarks/stats/' + id)
    stats = await response.json()
    console.log(stats)
    return stats
}

async function showStats(event) {
    stats = await getStats(event.target.idParameter)
    distributionDiagram(stats.distribution, document.getElementById("chart"))
}


async function AvarageDict(subjects) {
    const averages = {};

    for (const subject of subjects) {
        const stats = await getStats(subject.id);
        averages[subject.subjectName] = stats.average.toFixed(2); 
    }
    console.log(averages)
    return averages;
}

async function allStats() {
    const response = await fetch('http://localhost:5186/ExamMarks/stats');
    const stats = await response.json();
    console.log(stats);
  
    const container = document.getElementById("stats-panel");
  
    
    const card = document.createElement("div");
    card.classList.add("card", "mb-4", "shadow-sm");

    const cardBody = document.createElement("div");
    cardBody.classList.add("card-body");
  
  
    const title = document.createElement("h5");
    title.classList.add("card-title");
    title.textContent = "Statisztikák";
  

    const statList = document.createElement("ul");
    statList.classList.add("list-group", "list-group-flush", "mb-3");
  
    const avgItem = document.createElement("li");
    avgItem.classList.add("list-group-item");
    avgItem.innerHTML = `<p>Átlag:</p> ${stats.average.toFixed(2)}`;
  
    const medianItem = document.createElement("li");
    medianItem.classList.add("list-group-item");
    medianItem.innerHTML = `<p>Medián:</p> ${stats.median}`;
  
    const modeItem = document.createElement("li");
    modeItem.classList.add("list-group-item");
    modeItem.innerHTML = `<p>Módusz:</p> ${stats.mode}`;
  
    statList.append(avgItem, medianItem, modeItem);
  
 
    const distTitle = document.createElement("h6");
    distTitle.classList.add("mt-3");
    distTitle.textContent = "Eloszlás:";
  
  
    const distDiv = document.createElement("div");
    distDiv.classList.add("distributiondiv", "mt-2");

  

    const avgTitle = document.createElement("h6");
    avgTitle.classList.add("mt-3");
    avgTitle.textContent = "Átlag eloszlása:";
    const avgDiv = document.createElement("div");
    avgDiv.classList.add("mt-2");
  
  

    cardBody.append(title, statList, distTitle, distDiv, avgTitle, avgDiv);

  
    distributionDiagram(stats.distribution, distDiv); 
    distributionDiagram(await AvarageDict(subjects), avgDiv);
    

  
    card.appendChild(cardBody);
    container.appendChild(card);
  }
  


function distributionDiagram(distribution, container) {
    container.innerHTML = "";

    const maxCount = Math.max(...Object.values(distribution));

    for (const grade of Object.keys(distribution)) {
        const count = distribution[grade];

        const bar = document.createElement("div");
        bar.classList.add("bar");
        bar.style.height = `${(count / maxCount) * 100}%`;

        const value = document.createElement("div");
        value.textContent = count;

        const label = document.createElement("div");
        label.className = "bar-label";
        label.textContent = grade;

        bar.appendChild(value);
        bar.appendChild(label);
        container.appendChild(bar);
    }

  
    if (!container.classList.contains("chart-container")) {
        container.classList.add("chart-container");
    }
}

function deleteSubject(event) {
    fetch('http://localhost:5186/ExamMarks/' + event.target.idParameter, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(resp => {
            console.log('Response: ', resp)
            if (resp.status === 200) {
                window.location.href = "index.html";
            }
        })

}

function addSubject() {
    let subjectNameForm = document.getElementById('subject').value
    let marksList = document.getElementById("marks").value.split(';').map(m => parseInt(m.trim()));


    fetch('http://localhost:5186/ExamMarks/', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
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

