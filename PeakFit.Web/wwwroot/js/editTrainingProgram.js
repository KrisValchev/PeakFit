// Fetch exercises by CategoryId and populate dropdown
function populateExercises(categoryId, dropdown, selectedExerciseId = null) {
    dropdown.innerHTML = '<option value="">Select Exercise</option>';

    if (categoryId) {
        fetch(`/api/Exercise/GetByCategory?categoryId=${categoryId}`)
            .then(response => response.json())
            .then(exercises => {
                exercises.forEach(exercise => {
                    const option = document.createElement('option');
                    option.value = exercise.id;
                    option.textContent = exercise.exerciseName;

                    // Set the selected attribute if this is the pre-selected exercise
                    if (exercise.id === parseInt(selectedExerciseId)) {
                        option.selected = true;
                    }

                    dropdown.appendChild(option);
                });
            })
            .catch(error => console.error('Error fetching exercises:', error));
    }
}

// Populate all existing rows on page load
document.addEventListener('DOMContentLoaded', function () {
    const categoryId = document.getElementById('categoryId').value;
    const rows = document.querySelectorAll('#exercises-table tbody tr.exercise-row');
    rows.forEach(row => {
        const dropdown = row.querySelector('.exercise-dropdown');
        const selectedExerciseId = row.querySelector('.selected-exercise').value;
        populateExercises(categoryId, dropdown, selectedExerciseId);
    });

    // Update remove button visibility after populating rows
    updateRemoveButtons();
});

// Add new rows dynamically
let rowCount = document.querySelectorAll('#exercises-table tbody tr').length;
document.getElementById('add-row').addEventListener('click', function () {
    const tableBody = document.querySelector('#exercises-table tbody');
    const newRow = document.createElement('tr');
    newRow.classList.add('exercise-row');

    newRow.innerHTML = `
        <td>
            <select class="form-control exercise-dropdown" name="ProgramExercises[${rowCount}].ExerciseId" required>
                <option value="">Select Exercise</option>
            </select>
        </td>
        <td><input type="number" class="form-control" name="ProgramExercises[${rowCount}].Sets" min="1" required /></td>
        <td><input type="number" class="form-control" name="ProgramExercises[${rowCount}].Reps" min="1" required /></td>
        <td><button type="button" class="btn btn-danger remove-row">Remove</button></td>
    `;
    tableBody.appendChild(newRow);

    const categoryId = document.getElementById('categoryId').value;
    const newDropdown = newRow.querySelector('.exercise-dropdown');
    populateExercises(categoryId, newDropdown);

    rowCount++;
    updateRemoveButtons();
});

// Remove row
document.addEventListener('click', function (e) {
    if (e.target && e.target.classList.contains('remove-row')) {
        e.target.closest('tr').remove();
        updateRemoveButtons();
    }
});

// Update remove buttons visibility
function updateRemoveButtons() {
    const rows = document.querySelectorAll('#exercises-table tbody tr.exercise-row');
    rows.forEach((row, index) => {
        const removeButton = row.querySelector('.remove-row');
        if (rows.length === 1) {
            removeButton.style.display = 'none'; // Hide remove button if there's only one row
        } else {
            removeButton.style.display = ''; // Show remove button otherwise
        }
    });
}
// Remove row and recalculate indices
document.addEventListener('click', function (e) {
    if (e.target && e.target.classList.contains('remove-row')) {
        // Remove the row
        const rowToDelete = e.target.closest('tr');
        rowToDelete.remove();

        // Recalculate the indices for remaining rows
        const rows = document.querySelectorAll('#exercises-table tbody tr.exercise-row');
        rows.forEach((row, index) => {
            // Update the names for each input field
            const dropdown = row.querySelector('.exercise-dropdown');
            const setsInput = row.querySelector('input[name*=".Sets"]');
            const repsInput = row.querySelector('input[name*=".Reps"]');

            // Update names to match the new index
            if (dropdown) {
                dropdown.name = `ProgramExercises[${index}].ExerciseId`;
            }
            if (setsInput) {
                setsInput.name = `ProgramExercises[${index}].Sets`;
            }
            if (repsInput) {
                repsInput.name = `ProgramExercises[${index}].Reps`;
            }
        });

        // Decrement rowCount to ensure new rows start with the correct index
        rowCount = rows.length;

        updateRemoveButtons();
    }
});