<script setup lang="ts">
import { onMounted, ref } from 'vue';
import { useSubmissionStore } from '../../stores/submissionStore';
import { storeToRefs } from 'pinia';
import SubmissionCard from './SubmissionCard.vue';
import SearchBar from './SearchBar.vue';

const store = useSubmissionStore();
const { submissions, isLoading, error } = storeToRefs(store);
const searchTerm = ref('');

onMounted(() => {
  store.fetchSubmissions();
});

const handleSearch = (term: string) => {
  store.fetchSubmissions(term);
};
</script>

<template>
  <div class="submission-list-container">
    <SearchBar v-model="searchTerm" @search="handleSearch" />

    <div v-if="isLoading" class="loading-state">
      Loading submissions...
    </div>

    <div v-else-if="error" class="error-state">
      {{ error }}
    </div>

    <div v-else-if="submissions.length === 0" class="empty-state">
      No submissions found.
    </div>

    <div v-else class="submission-list">
      <SubmissionCard
        v-for="submission in submissions"
        :key="submission.id"
        :submission="submission"
      />
    </div>
  </div>
</template>

<style scoped lang="scss">
.submission-list-container {
  padding: 1rem;
}

.loading-state,
.error-state,
.empty-state {
  text-align: center;
  padding: 2rem;
  color: #6c757d;
  font-size: 1.1rem;
}

.error-state {
  color: #dc3545;
}
</style>
