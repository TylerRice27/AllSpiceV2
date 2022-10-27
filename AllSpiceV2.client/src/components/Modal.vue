<template>
	<!-- Button trigger modal -->
	<!-- <button
		type="button"
		class="btn btn-primary"
		data-bs-toggle="modal"
		data-bs-target="#staticBackdrop"
	>
		Launch static backdrop modal
	</button> -->

	<!-- Modal -->
	<div
		class="modal fade"
		id="staticBackdrop"
		data-bs-backdrop="static"
		data-bs-keyboard="false"
		tabindex="-1"
		aria-labelledby="staticBackdropLabel"
		aria-hidden="true"
	>
		<div class="modal-dialog">
			<div class="modal-content">
				<slot class="modal-header" name="header">
					<!-- <h1 class="modal-title fs-5" id="staticBackdropLabel">Modal title</h1> -->
					<button
						type="button"
						class="btn-close"
						data-bs-dismiss="modal"
						aria-label="Close"
					></button>
				</slot>
				<slot class="modal-body" name="body"></slot>
				<div class="modal-footer">
					<button type="button" class="btn btn-danger" data-bs-dismiss="modal">
						Close
					</button>
					<button type="button" class="btn btn-none glass text-white">
						Create
					</button>
				</div>
			</div>
		</div>
	</div>
</template>


<script>
export default {
	setup() {
		return {}
	}
}
</script>


<style lang="scss" scoped>
</style>