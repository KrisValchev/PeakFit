
// Fetch categories from API and populate dropdown
function populateExercises(categoryId, dropdown) {
    // Clear existing exercises
    dropdown.innerHTML = '<option value="">Select Exercise</option>';

    if (categoryId) {
        fetch(`/api/Exercise/GetByCategory?categoryId=${categoryId}`)
            .then(response => response.json())
            .then(exercises => {
                exercises.forEach(exercise => {
                    const option = document.createElement('option');
                    option.value = exercise.id;
                    option.textContent = exercise.exerciseName; // Adjust based on API response structure
                    dropdown.appendChild(option);
                });
            })
            .catch(error => console.error('Error fetching exercises:', error));
    }
}
// Populate exercises dropdown based on selected category
document.getElementById('categoryDropdown').addEventListener('change', function () {
    const categoryId = this.value;
    //const exerciseDropdown = document.getElementById('exerciseDropdown');
    //populateExercises(categoryId, exerciseDropdown);
    const exerciseDropdowns = document.querySelectorAll('.exercise-dropdown');
    // Update all dropdowns in the table
    exerciseDropdowns.forEach(dropdown => populateExercises(categoryId, dropdown));
    // Clear existing exercises

});

let rowCount = 1;
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
    <td><input type="number" class="form-control" id="exerciseDropDown${rowCount}" name="ProgramExercises[${rowCount}].Sets" min="1" required /></td>
    <td><input type="number" class="form-control" name="ProgramExercises[${rowCount}].Reps" min="1" required /></td>
    <td><button type="button" class="btn btn-danger remove-row">Remove</button></td>
    `;
    tableBody.appendChild(newRow);

    // Populate the dropdown in the new row
    const categoryId = document.getElementById('categoryDropdown').value;
    const newDropdown = newRow.querySelector('.exercise-dropdown');
    populateExercises(categoryId, newDropdown); // Call reusable function

    rowCount++;
    updateRemoveButtons();
});




// Remove row
document.addEventListener('click', function (e) {
    if (e.target && e.target.classList.contains('remove-row')) {
        e.target.closest('tr').remove();
    }
});


// Update Remove buttons based on row count
function updateRemoveButtons() {
    const rows = document.querySelectorAll('#exercises-table tbody tr.exercise-row');
    rows.forEach((row, index) => {
        const removeButton = row.querySelector('.remove-row');
        if (rows.length === 1) {
            // Hide or remove the button if only one row exists
            if (removeButton) {
                removeButton.style.display = 'none'; // You can also use `remove()` to delete the button completely
            }
        } else {
            // Ensure the Remove button is visible if more than one row exists
            if (removeButton) {
                removeButton.style.display = ''; // Reset display to default
            }
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



// Run this function on page load to handle the initial row
updateRemoveButtons();