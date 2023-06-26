const uri = 'api/Teams';
let teams = [];

function getTeams() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayTeams(data))
        .catch(error => console.error('Unable to get teams.', error));
}

function addTeam() {
    const addNameTextbox = document.getElementById('add-name');
    const addInfoTextbox = document.getElementById('add-country');
  

    const team = {
        name: addNameTextbox.value.trim(),
        info: addInfoTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(team)
    })
        .then(response => response.json())
        .then(() => {
            getTeams();
            addNameTextbox.value = '';
            addInfoTextbox.value = '';
        })
        .catch(error => console.error('Unable to add team.', error));
}

function deleteTeam(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getTeams())
        .catch(error => console.error('Unable to delete team.', error));
}

function displayEditForm(id) {
    const team = teams.find(team => team.id === id);

    document.getElementById('edit-id').value = team.id;
    document.getElementById('edit-name').value = team.name;
    document.getElementById('edit-country').value = team.country;
    document.getElementById('editForm').style.display = 'block';
}

function updateTeam() {
    const teamId = document.getElementById('edit-id').value;
    const team = {
        id: parseInt(teamId, 10),
        name: document.getElementById('edit-name').value.trim(),
        info: document.getElementById('edit-country').value.trim()
    };

    fetch(`${uri}/${teamId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(team)
    })
        .then(() => getTeams())
        .catch(error => console.error('Unable to update team.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayTeams(data) {
    const tBody = document.getElementById('teams');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(team => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${team.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteTeam(${team.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(team.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNodeInfo = document.createTextNode(team.country);
        td2.appendChild(textNodeInfo);

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });

    teams = data;
}

