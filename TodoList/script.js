document.addEventListener('DOMContentLoaded', () => {
    const taskInput = document.getElementById('taskInput');
    const addTaskBtn = document.getElementById('addTaskBtn');
    const taskList = document.getElementById('taskList');
    const taskModal = document.getElementById('taskModal');
    const modalText = document.getElementById('modalText');
    const closeBtn = document.querySelector('.close');

    addTaskBtn.addEventListener('click', () => {
        const taskText = taskInput.value.trim();
        if (taskText !== '') {
            const li = document.createElement('li');
            li.className = 'taskItem';

            const span = document.createElement('span');
            span.className = 'taskText';
            span.textContent = taskText;

            const deleteBtn = document.createElement('button');
            deleteBtn.className = 'deleteBtn';
            deleteBtn.innerHTML = '<img src="dustbin-icon.svg" alt="Delete">';

            deleteBtn.addEventListener('click', (e) => {
                e.stopPropagation();
                li.remove();
            });

            li.appendChild(span);
            li.appendChild(deleteBtn);

            li.addEventListener('click', () => {
                modalText.textContent = taskText;
                taskModal.style.display = 'flex';
            });

            taskList.appendChild(li);
            taskInput.value = '';
        }
    });

    closeBtn.addEventListener('click', () => {
        taskModal.style.display = 'none';
    });

    window.addEventListener('click', (e) => {
        if (e.target === taskModal) {
            taskModal.style.display = 'none';
        }
    });
});
