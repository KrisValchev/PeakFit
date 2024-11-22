document.querySelectorAll('.ratingStars .starsToRate').forEach(star => {
    star.addEventListener('click', function () {
        const value = this.getAttribute('data-value');
        const itemId = this.parentNode.getAttribute('data-item-id');
        const userId = document.getElementById('current-user-id').value;
        // Highlight selected stars
        this.parentNode.querySelectorAll('.starsToRate').forEach(s => {
            s.classList.remove('selected');
            if (s.getAttribute('data-value') <= value) {
                s.classList.add('selected');
            }
        });

        // Send the rating to the server
        fetch(`/api/Rating`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                trainingProgramId: parseInt(itemId),
                userId: userId,
                value: parseInt(value)
            })
        })
            .then(response => response.json())
            .then(data => {
                if (data.averageRating !== undefined && data.totalRatings !== undefined) {
                    const ratingSection = document.getElementById('average-rating-section');
                    if (ratingSection) {
                        let starsHtml = '';
                        for (let i = 0; i < 5; i++) {
                            if (i < data.averageRating) {
                                starsHtml += '<span class="star filled">&#9733;</span>';
                            } else {
                                starsHtml += '<span class="star">&#9734;</span>';
                            }
                        }
                        // Update the displayed average rating
                        document.querySelector(`#average-rating-${itemId}`).textContent = `(${data.averageRating.toFixed(2)})`;

                        // Update the displayed total ratings
                        document.querySelector(`#total-ratings-${itemId}`).textContent = `(${data.totalRatings} Ratings)`;
                        ratingSection.innerHTML = starsHtml;
                    }
                }

                alert(data.message);
            })
            .catch(error => console.error('Error submitting rating:', error));

    });
});
document.addEventListener('DOMContentLoaded', function () {
    // Get all programs with a star rating
    document.querySelectorAll('.ratingStars').forEach(starContainer => {
        const trainingProgramId = starContainer.getAttribute('data-item-id');
        const userId = document.getElementById('current-user-id').value;

        // Fetch the existing rating for the program
        fetch(`/api/Rating/${trainingProgramId}`)
            .then(response => response.json())
            .then(data => {
                const ratingValue = data.ratingValue; // Get the rating value from the server

                // Highlight stars based on the retrieved rating
                if (ratingValue > 0) {
                    starContainer.querySelectorAll('.starsToRate').forEach(star => {
                        if (parseInt(star.getAttribute('data-value')) <= ratingValue) {
                            star.classList.add('selected');
                        }
                    });
                }
            })
            .catch(error => console.error('Error fetching rating:', error));
    });
});