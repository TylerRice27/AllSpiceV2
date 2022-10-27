<template>
	<form>
		<div class="mb-1 p-3">
			<label>Title</label>
			<input type="" class="form-control" />
		</div>
		<div class="mb-1 p-3">
			<label>Image</label>
			<input type="" class="form-control" />
		</div>
		<div class="mb-1 p-3">
			<label>Instructions</label>
			<input type="" class="form-control" />
		</div>
		<div class="mb-1 p-3">
			<label>Category</label>
			<input type="" class="form-control" />
		</div>
		<div class="modal-footer">
			<button type="button" class="btn btn-danger" data-bs-dismiss="modal">
				Close
			</button>
			<button type="button" class="btn btn-none glass text-white">
				Create
			</button>
		</div>
	</form>
</template>


<script>
export default {
	setup() {
		return {}
	}
}
</script>


<style lang="scss" scoped>
input {
	border: none !important;
	margin-top: 3px;
}
</style>