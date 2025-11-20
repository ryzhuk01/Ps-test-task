<script setup lang="ts">
import type { FormSubmission } from '../../types/submission';

defineProps<{
  submission: FormSubmission;
}>();

const formatDate = (dateString: string) => {
  return new Date(dateString).toLocaleString();
};

// Format to readable format
const formatKey = (key: string) => {
  const result = key.replace(/([A-Z])/g, ' $1').toLowerCase();
  return result.charAt(0).toUpperCase() + result.slice(1);
};
</script>

<template>
  <div class="submission-card">
    <div class="card-header">
      <h3 class="form-name">{{ submission.formName }}</h3>
      <span class="submission-date">{{ formatDate(submission.submittedAt) }}</span>
    </div>
    <div class="card-body">
      <div v-for="(value, key) in submission.formData" :key="key" class="data-row">
        <span class="data-key">{{ formatKey(key) }}:</span>
        <span class="data-value">{{ value }}</span>
      </div>
    </div>
  </div>
</template>

<style scoped lang="scss">
.submission-card {
  background: #fff;
  border: 1px solid #e0e0e0;
  border-radius: 8px;
  padding: 1rem;
  margin-bottom: 1rem;
  transition: box-shadow 0.2s;

  &:hover {
    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
  }

  .card-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: 0.75rem;
    padding-bottom: 0.5rem;
    border-bottom: 1px solid #f0f0f0;

    .form-name {
      margin: 0;
      font-size: 1.1rem;
      color: #2c3e50;
    }

    .submission-date {
      font-size: 0.85rem;
      color: #6c757d;
    }
  }

  .card-body {
    .data-row {
      display: flex;
      margin-bottom: 0.25rem;
      font-size: 0.95rem;

      .data-key {
        font-weight: 600;
        margin-right: 0.5rem;
        color: #495057;
        min-width: 100px;
      }

      .data-value {
        color: #212529;
        word-break: break-word;
      }
    }
  }
}
</style>
