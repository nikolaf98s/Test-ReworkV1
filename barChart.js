const apiURL = "https://localhost:5001/Survey/report";

function onload() {
  fetch(apiURL)
    .then((response) => response.json())
    .then((json) => loadBarChart(json))
    .catch(console.error());
}

function loadBarChart(json) {
  console.log(json);
  avgScore = [];
  labels = [];
  colors = [];

  i = 0;
  json.forEach((element) => {
    avgScore[i] = element.averageRating;
    labels[i] = element.name;
    colors[i] =
      "rgb(" +
      getRandomNumber() +
      ", " +
      getRandomNumber() +
      "," +
      getRandomNumber() +
      ")";
    i++;
  });
  const data = {
    labels: labels,
    datasets: [
      {
        backgroundColor: colors,
        data: avgScore,
      },
    ],
  };
  const config = {
    type: "bar",
    data: data,
    options: {
      responsive: true,
      plugins: {
        legend: {
          display: false,
        },
      },
    },
  };
  var myChart = new Chart(document.getElementById("BarChart"), config);
}

function getRandomNumber() {
  from = 0;
  to = 255;
  return Math.floor(Math.random() * (to - from) + from);
}
