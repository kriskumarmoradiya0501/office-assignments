// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// AJAX mode: comment out this block to use the original MVC form submissions.
(function () {
	function showMessage(message, type) {
		var messageElement = document.getElementById("ajaxMessage");
		if (!messageElement) {
			messageElement = document.createElement("div");
			messageElement.id = "ajaxMessage";
			document.querySelector("main")?.prepend(messageElement);
		}

		messageElement.className = "alert alert-" + type;
		messageElement.textContent = message;
		messageElement.hidden = false;
		window.setTimeout(function () { messageElement.hidden = true; }, 3000);
	}

	function showValidationErrors(form, errors) {
		form.querySelectorAll("[data-ajax-error]").forEach(function (element) {
			element.textContent = "";
		});

		Object.keys(errors || {}).forEach(function (fieldName) {
			var field = form.querySelector("[data-valmsg-for='" + fieldName + "']");
			if (field) {
				field.textContent = errors[fieldName].join(" ");
			}
		});
	}

	document.addEventListener("submit", async function (event) {
		var form = event.target.closest("form[data-ajax='true']");
		if (!form || event.defaultPrevented) {
			return;
		}

		event.preventDefault();
		var submitButton = form.querySelector("[type='submit']");
		if (submitButton) submitButton.disabled = true;

		try {
			var response = await fetch(form.action, {
				method: form.method || "POST",
				body: new FormData(form),
				headers: { "X-Requested-With": "XMLHttpRequest" }
			});

			var result = await response.json();

			if (!response.ok) {
				showValidationErrors(form, result.errors);
				showMessage("Please correct the highlighted fields.", "danger");
				return;
			}

			showMessage(result.message, "success");
			var modalId = form.dataset.ajaxModal;
			var modalElement = modalId ? document.getElementById(modalId) : null;
			if (modalElement && window.bootstrap) {
				bootstrap.Modal.getOrCreateInstance(modalElement).hide();
				form.reset();
			}
			window.setTimeout(function () {
				window.location.href = "/MVCIntern/GetAll";
			}, 500);
		} catch (error) {
			showMessage("The request could not be completed.", "danger");
		} finally {
			if (submitButton) submitButton.disabled = false;
		}
	});

	document.addEventListener("click", async function (event) {
		var detailButton = event.target.closest("[data-ajax-detail-url]");
		var editButton = event.target.closest("[data-ajax-edit-url]");
		if (!detailButton && !editButton) {
			return;
		}

		var button = detailButton || editButton;
		try {
			var response = await fetch(button.dataset.ajaxDetailUrl || button.dataset.ajaxEditUrl);
			if (!response.ok) throw new Error();
			var intern = await response.json();

			if (detailButton) {
				document.getElementById("detailInternContent").innerHTML =
					"<dl class='row mb-0'>" +
					"<dt class='col-sm-5'>Intern ID</dt><dd class='col-sm-7'>" + intern.internId + "</dd>" +
					"<dt class='col-sm-5'>Name</dt><dd class='col-sm-7'>" + intern.internName + "</dd>" +
					"<dt class='col-sm-5'>Gender</dt><dd class='col-sm-7'>" + (intern.gender === "M" ? "Male" : "Female") + "</dd>" +
					"<dt class='col-sm-5'>Topic</dt><dd class='col-sm-7'>" + (intern.assignedTopic?.topicName || "N/A") + "</dd>" +
					"<dt class='col-sm-5'>Presentation Date</dt><dd class='col-sm-7'>" + intern.dateOfPresentation + "</dd>" +
					"<dt class='col-sm-5'>Status</dt><dd class='col-sm-7'>" + (intern.status ? "Presented" : "Not Presented") + "</dd>" +
					"</dl>";
			} else {
				var form = document.getElementById("editInternForm");
				form.action = editButton.dataset.ajaxUpdateUrl;
				form.elements.InternId.value = intern.internId;
				form.elements.InternName.value = intern.internName || "";
				form.elements.Gender.value = intern.gender || "";
				form.elements.TopicId.value = intern.topicId || "";
				form.elements.DateOfPresentation.value = intern.dateOfPresentation || "";
				form.elements.Status.checked = intern.status;
			}
		} catch (error) {
			document.getElementById("detailInternContent")?.replaceChildren(document.createTextNode("The intern details could not be loaded."));
			showMessage("The intern details could not be loaded.", "danger");
		}
	});

	document.addEventListener("click", async function (event) {
		var button = event.target.closest("[data-ajax-delete-url]");
		if (!button) {
			return;
		}

		event.preventDefault();
		if (!window.confirm("Are you sure you want to delete this intern?")) {
			return;
		}

		button.disabled = true;
		try {
			var response = await fetch(button.dataset.ajaxDeleteUrl, {
				method: "POST",
				headers: { "X-Requested-With": "XMLHttpRequest" }
			});
			var result = await response.json();
			if (!response.ok) throw new Error();

			button.closest("tr")?.remove();
			showMessage(result.message, "success");
		} catch (error) {
			button.disabled = false;
			showMessage("The intern could not be deleted.", "danger");
		}
	});
})();
