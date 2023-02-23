// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



	function rebindvalidators() {
		var $form = $("#EditForm");
		$form.unbind();
		$form.data("validator", null);
		$.validator.unobtrusive.parse($form);
		$form.validate($form.data("unobtrusiveValidation").options);
	}
