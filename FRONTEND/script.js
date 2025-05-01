async function downloadAndDisplay() {
    const response = await fetch('http://localhost:5065/')
    const subjects = await response.json()
    console.log(subjects)

    document.querySelector('#subjects').innerHTML = ''
    
    if(length(subjects) == 0)
    {
    
    }
    subjects.map(x => {
        developers.push(x)

        let tr = document.createElement('tr')
        let tdID = document.createElement('td')
        let tdName = document.createElement('td')
        let tdJob = document.createElement('td')
        let tdSalary = document.createElement('td')
        let tdIsActive = document.createElement('td')
        let tdActions = document.createElement('td')

        tdID.innerHTML =  x.id
        tdName.innerHTML = x.name
        tdJob.innerHTML = x.job
        tdSalary.innerHTML = x.salary
        tdIsActive.innerHTML = x.isActive == true ? '&check;' : '×'
        
        tr.appendChild(tdID)
        tr.appendChild(tdName)
        tr.appendChild(tdJob)
        tr.appendChild(tdSalary)
        tr.appendChild(tdIsActive)
        tr.appendChild(tdActions)

        let btnUpdate = document.createElement('button')
        btnUpdate.classList.add('btn')
        btnUpdate.classList.add('btn-sm')
        btnUpdate.classList.add('btn-warning')
        btnUpdate.classList.add('mx-2')
        btnUpdate.innerHTML = 'Update'
        btnUpdate.idParameter = x.id
        btnUpdate.addEventListener('click', updateLog)
        tdActions.appendChild(btnUpdate)

        let btnDel = document.createElement('button')
        btnDel.classList.add('btn')
        btnDel.classList.add('btn-sm')
        btnDel.classList.add('btn-danger')
        btnDel.classList.add('mx-2')
        btnDel.innerHTML = 'Delete'
        btnDel.idParameter = x.id
        btnDel.addEventListener('click', deleteLog)
        tdActions.appendChild(btnDel)

        document.querySelector('#devs').appendChild(tr)
    })
}

downloadAndDisplay();